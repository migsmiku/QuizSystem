namespace OnlineQuiz.DAL
{
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Transactions;
    using Microsoft.CodeAnalysis.Options;
    using Microsoft.Extensions.Options;
    using OnlineQuiz.Models;
    using Options = Models.Options;

    public class QuizDAL : DALBase, IQuizDAL
    {
        public QuizDAL(IConfiguration config) : base(config)
        {
        }

        public QuizViewModel CreateQuiz(int quizCategoryId, string? quizName, int userId)
        {
            QuizViewModel quizViewModel = new()
            {
                UserId = userId,
                QuizName = quizName,
            };
            using (TransactionScope scope = new())
            {
                using SqlConnection conn = Connection;
                conn.Open();

                using (SqlCommand command = new("INSERT INTO Quizzes (QuizName, QuizCategoryId) OUTPUT INSERTED.QuizId VALUES (@QuizName, @QuizCategoryId)", conn))
                {
                    command.Parameters.Add("@QuizName", SqlDbType.VarChar).Value = quizName;
                    command.Parameters.Add("@QuizCategoryId", SqlDbType.Int).Value = quizCategoryId;
                    int quizId = (int)command.ExecuteScalar();
                    quizViewModel.QuizId = quizId;
                }

                using (SqlCommand command = new("SELECT TOP 10 Q.* FROM Questions Q Where QuizCategoryID = @QuizCategoryId ORDER BY NEWID()", conn))
                {
                    command.Parameters.Add("@QuizCategoryId", SqlDbType.Int).Value = quizCategoryId;
                    using SqlDataReader reader = command.ExecuteReader();
                    quizViewModel.Questions = new List<Questions>();
                    while (reader.Read())
                    {
                        Questions question = new()
                        {
                            QuestionId = (int)reader["QuestionID"],
                            QuizCategoryId = (int)reader["QuizCategoryID"],
                            QuestionText = (string)reader["QuestionText"],
                            QuestionType = (int)reader["QuestionType"],
                            CreatedDate = (DateTime)reader["CreatedDate"]
                        };
                        quizViewModel.Questions.Add(question);
                    }
                }

                List<int> questionsIds = quizViewModel.Questions.Select(x => x.QuestionId).ToList();
                using (SqlCommand command = new("SELECT * FROM Options WHERE QuestionID IN (SELECT value FROM STRING_SPLIT(@questionsIds, ','))", conn))
                {
                    command.Parameters.Add("@questionsIds", SqlDbType.VarChar).Value = string.Join(",", questionsIds);
                    using SqlDataReader reader = command.ExecuteReader();
                    quizViewModel.Options = new List<Options>();
                    while (reader.Read())
                    {
                        Options option = new()
                        {
                            OptionId = (int)reader["OptionID"],
                            QuestionId = (int)reader["QuestionID"],
                            OptionText = (string)reader["OptionText"],
                            IsCorrect = (bool)reader["IsCorrect"],
                        };
                        quizViewModel.Options.Add(option);
                    }
                }

                using (SqlCommand command = new("INSERT INTO QuizQuestions (QuizId, QuestionId, SelectedOptionId, CreatedDate) OUTPUT INSERTED.QuizQuestionId VALUES (@QuizId, @QuestionId, @SelectedOptionId, @CreatedDate)", conn))
                {
                    _ = command.Parameters.AddWithValue("@QuizId", quizViewModel.QuizId);
                    _ = command.Parameters.AddWithValue("@SelectedOptionId", 0);
                    _ = command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                    _ = command.Parameters.Add("@QuestionId", SqlDbType.Int);
                    List<QuizQuestions> quizQuestions = new();

                    foreach (Questions? question in quizViewModel.Questions)
                    {
                        command.Parameters["@QuestionId"].Value = question?.QuestionId;
                        int quizQuestionId = (int)command.ExecuteScalar();
                        quizQuestions.Add(new QuizQuestions
                        {
                            QuizQuestionId = quizQuestionId,
                            QuizId = quizViewModel.QuizId,
                            QuestionId = question.QuestionId,
                            SelectedOptionId = 0,
                            CreatedDate = DateTime.Now
                        });
                    }
                    quizViewModel.QuizQuestions = quizQuestions;
                }

                using (SqlCommand command = new("INSERT INTO QuizSubmissions (QuizID, UserID, StartTime, Score, CreatedDate) OUTPUT INSERTED.QuizSubmissionID VALUES (@QuizID, @UserID, @StartTime, @Score, @CreatedDate)", conn))
                {
                    DateTime current = DateTime.Now;
                    _ = command.Parameters.AddWithValue("@QuizID", quizViewModel.QuizId);
                    _ = command.Parameters.AddWithValue("@UserID", quizViewModel.UserId);
                    _ = command.Parameters.AddWithValue("@StartTime", current);
                    _ = command.Parameters.AddWithValue("@Score", 0);
                    _ = command.Parameters.AddWithValue("@CreatedDate", current);
                    int quizSubmissionId = (int)command.ExecuteScalar();
                    quizViewModel.QuizSubmissions = new QuizSubmissions()
                    {
                        QuizSubmissionId = quizSubmissionId,
                        UserId = quizViewModel.UserId,
                        QuizId = quizViewModel.QuizId,
                        StartTime = current,
                        EndTime = null,
                        Score = 0,
                        CreatedDate = current,
                    };
                }
                scope.Complete();
            }

            return quizViewModel;
        }

        public void CreateUser(Users user)
        {
            using TransactionScope transactionScope = new();
            using SqlConnection conn = Connection;
            conn.Open();
            SqlCommand command = new("INSERT INTO Users (UserName, FirstName, LastName, Email, DateOfBirth, [Password], UserRoleId) VALUES (@UserName, @FirstName, @LastName, @Email, @DateOfBirth, @Password, @UserRoleId);", conn);
            command.Parameters.AddRange(new SqlParameter[]
            {
                    new SqlParameter("@UserName", user.UserName),
                    new SqlParameter("@FirstName", user.FirstName),
                    new SqlParameter("@LastName", user.LastName),
                    new SqlParameter("@Email", user.Email),
                    new SqlParameter("@DateOfBirth", user.DateOfBirth),
                    new SqlParameter("@Password", user.Password),
                    new SqlParameter("@UserRoleId", user.UserRoleId)
            });
            _ = command.ExecuteNonQuery();
            transactionScope.Complete();
        }

        public IEnumerable<QuizCategory> GetQuizCategory()
        {
            using SqlConnection conn = Connection;
            conn.Open();
            SqlCommand command = new("SELECT * FROM QuizCategories", conn);
            using SqlDataReader reader = command.ExecuteReader();
            List<QuizCategory> quizCategories = new();
            while (reader.Read())
            {
                QuizCategory quizCategory = new()
                {
                    QuizCategoryId = reader.GetInt32(0),
                    QuizCategoryName = reader.GetString(1)
                };
                quizCategories.Add(quizCategory);
            }
            return quizCategories.AsEnumerable();
        }

        public QuizViewModel GetQuizViewModel(int? quizId)
        {
            QuizViewModel quizViewModel = new QuizViewModel();
            using (SqlConnection conn = Connection)
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Quizzes WHERE QuizID = @quizId", conn))
                {
                    command.Parameters.AddWithValue("@quizId", quizId);
                    using var reader = command.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        quizViewModel.QuizId = (int)reader["QuizId"];
                        quizViewModel.QuizName = reader["QuizName"].ToString();
                    }
                    
                };


                using (var command = new SqlCommand("SELECT qq.* FROM QuizQuestions qq WHERE qq.QuizId = @quizId", conn))
                {
                    command.Parameters.AddWithValue("@quizId", quizId);
                    List<QuizQuestions> quizQuestions = new List<QuizQuestions>();
                    using var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        QuizQuestions question = new QuizQuestions()
                        {
                            QuizQuestionId = (int)reader["QuizQuestionId"],
                            QuizId = (int)reader["QuizId"],
                            QuestionId = (int)reader["QuestionId"],
                            SelectedOptionId = (int)reader["SelectedOptionId"],
                            CreatedDate = (DateTime)reader["CreatedDate"]
                        };
                        quizQuestions.Add(question);
                    }
                    quizViewModel.QuizQuestions = quizQuestions;
                }

                List<int> questionsIds = quizViewModel.QuizQuestions.Select(x => x.QuestionId).ToList();                
                using (SqlCommand command = new SqlCommand("SELECT * FROM Questions WHERE QuestionID IN (SELECT value FROM STRING_SPLIT(@questionsIds, ','))", conn))
                {
                    command.Parameters.Add("@questionsIds", SqlDbType.VarChar).Value = string.Join(",", questionsIds);
                    using SqlDataReader reader = command.ExecuteReader();
                    var questions = new List<Questions>();
                    while (reader.Read())
                    {
                        var question = new Questions
                        {
                            QuestionId = (int)reader["QuestionId"],
                            QuizCategoryId = (int)reader["QuizCategoryId"],
                            QuestionText = reader["QuestionText"].ToString(),
                            QuestionType = (int)reader["QuestionType"],
                            CreatedDate = (DateTime)reader["CreatedDate"]
                        };
                        questions.Add(question);
                    }
                    quizViewModel.Questions = questions;
                }
                               
                quizViewModel.Options = GetOptionsByQuizId(quizId, conn);

                quizViewModel.QuizSubmissions = GetQuizSubmissionsById(quizId, conn);
            }

            return quizViewModel;
        }

        private QuizSubmissions? GetQuizSubmissionsById(int? quizId, SqlConnection conn)
        {
            using (SqlCommand command = new("SELECT * FROM QuizSubmissions WHERE QuizID = @quizId", conn))
            {
                command.Parameters.Add("@quizId", SqlDbType.Int).Value = quizId;
                using SqlDataReader reader = command.ExecuteReader();
                QuizSubmissions quizSubmissions = new QuizSubmissions();
                while (reader.Read())
                {                        
                    quizSubmissions.QuizSubmissionId = (int)reader["QuizSubmissionId"];
                    quizSubmissions.QuizId = (int)reader["QuizId"];
                    quizSubmissions.UserId = (int)reader["UserId"];
                    quizSubmissions.StartTime = (DateTime)reader["StartTime"];
                    quizSubmissions.EndTime = reader["EndTime"] is null?(DateTime)reader["EndTime"]:null;
                    quizSubmissions.Score = (int)reader["Score"];
                    quizSubmissions.CreatedDate = (DateTime)reader["CreatedDate"];                        
                }
                return quizSubmissions;
            }            
        }

        private IList<Options> GetOptionsByQuizId(int? quizId, SqlConnection conn)
        {            
            using (SqlCommand command = new("SELECT * FROM Options WHERE QuestionID IN (SELECT QuestionID FROM QuizQuestions WHERE QuizID = @quizId)", conn))
            {
                command.Parameters.Add("@quizId", SqlDbType.Int).Value = quizId;
                using SqlDataReader reader = command.ExecuteReader();
                var options = new List<Options>();
                while (reader.Read())
                {
                    Options option = new()
                    {
                        OptionId = (int)reader["OptionID"],
                        QuestionId = (int)reader["QuestionID"],
                        OptionText = (string)reader["OptionText"],
                        IsCorrect = (bool)reader["IsCorrect"],
                    };
                    options.Add(option);
                }
                return options;
            }                    
        }

        public Users? Login(string userName, string password)
        {
            try
            {
                using SqlConnection conn = Connection;
                conn.Open();
                SqlCommand command = new("SELECT * FROM Users WHERE UserName = @username AND Password = @password;", conn);
                command.Parameters.AddRange(new SqlParameter[]
                    {
                    new SqlParameter("@UserName", userName),
                    new SqlParameter("@Password", password),
                    });
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Users user = new()
                    {
                        UserID = reader.GetInt32(0),
                        UserName = reader.GetString(1),
                        FirstName = reader.GetString(2),
                        LastName = reader.GetString(3),
                        Email = reader.GetString(4),
                        DateOfBirth = reader.GetDateTime(5),
                        Password = reader.GetString(6),
                        UserRoleId = reader.GetInt32(7)
                    };
                    return user;
                }
            }
            catch (Exception)
            {

                return null;
            }

            return null;
        }

    }
}
