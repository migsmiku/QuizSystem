namespace OnlineQuiz.Controllers
{
    using System.Diagnostics;
    using System.Transactions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using OnlineQuiz.DbContext;
    using OnlineQuiz.Models;
    using OnlineQuiz.Models.Enum;

    [Authorize(Policy = "Admin")]
    public class AdminController : Controller
    {
        private readonly QuizDbContext _quizDbContext;

        public AdminController(QuizDbContext quizDbContext)
        {
            _quizDbContext = quizDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ViewQuizResult(IFormCollection form, string categoryFilter, string userFilter, int pageNumber = 1, int pageSize = 20)
        {
            IQueryable<QuizSubmissions> quizSubmissions = _quizDbContext.QuizSubmissions.AsNoTracking()
                                                                                        .Where(x => categoryFilter == null || x.Quizzes.QuizCategories.QuizCategoryName == ((QuizCategory)Enum.Parse(typeof(QuizCategory), categoryFilter)).ToDescription())
                                                                                        .Where(u => userFilter == null || u.UserId == Convert.ToInt32(userFilter))
                                                                                        .Include(x => x.Quizzes)
                                                                                        .ThenInclude(q => q.QuizQuestions)
                                                                                        .Include(u => u.Users)
                                                                                        .AsQueryable()
                                                                                        .OrderByDescending(x => x.EndTime);
                                                                                        

            int totalRecords = await quizSubmissions.CountAsync();
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            AdminViewModel adminViewModel = new()
            {
                TotalRecords = totalRecords,
                TotalPages = totalPages,
                PageNumber = pageNumber,
                CategoryFilter = categoryFilter,
                UserFilter = userFilter,
                QuizSubmissions = quizSubmissions.Skip((pageNumber - 1) * pageSize)
                                                .Take(pageSize)
            };

            return View(adminViewModel);
        }

        [Route("Admin/ViewQuizResult/ViewUserProfile")]
        public async Task<IActionResult> ViewUserProfile([FromQuery] int userId)
        {
            Users? user = await _quizDbContext.Users.SingleOrDefaultAsync(x => x.UserID.Equals(userId));
            return user == null
                ? View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier })
                : (IActionResult)View("_ViewUserProfilePartial", user);
        }

        [Route("Admin/ViewAllUserProfile")]
        public IActionResult ViewAllUserProfile(int pageNumber = 1, int pageSize = 20)
        {
            IQueryable<Users> users = _quizDbContext.Users.AsNoTrackingWithIdentityResolution();
            if (users == null) { return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }); }
            int totalRecords = users.Count();
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            AdminViewModel adminViewModel = new()
            {
                TotalRecords = totalRecords,
                TotalPages = totalPages,
                PageNumber = pageNumber,
                Users = users.Skip((pageNumber - 1) * pageSize)
                                                .Take(pageSize)
            };

            return View(adminViewModel);
        }

        public async Task<IActionResult> ManageUserStatus(int userId, string status)
        {
            Users user = _quizDbContext.Users.Single(x => x.UserID == userId);
            user.UserStatus = status == "Active";
            _ = await _quizDbContext.SaveChangesAsync();
            return RedirectToAction("ViewAllUserProfile");
        }

        [Route("/Admin/EditQuestions")]
        public async Task<IActionResult> EditQuestions(int pageNumber = 1, int pageSize = 20)
        {
            var questions = _quizDbContext.Questions.AsNoTracking();
            if (questions == null) { return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }); }
            int totalRecords = questions.Count();
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            AdminViewModel adminViewModel = new()
            {
                TotalRecords = totalRecords,
                TotalPages = totalPages,
                PageNumber = pageNumber,
                Questions = await questions.Skip((pageNumber - 1) * pageSize)
                                                .Take(pageSize).ToListAsync()
            };
            return View(adminViewModel);
        }

        public async Task<IActionResult> UpdateQuestionStatus(int questionId)
        {
            var question = await _quizDbContext.Questions.FirstOrDefaultAsync(x =>x.QuestionId.Equals(questionId));
            question.QuestionStatus = !question.QuestionStatus;
            await _quizDbContext.SaveChangesAsync();

            return RedirectToAction("EditQuestions");
        }

        public async Task<IActionResult> GetQuestionDetail(int questionId)
        {
            var question = await _quizDbContext.Questions.Include(x => x.Options)
                                                         .FirstOrDefaultAsync(x => x.QuestionId.Equals(questionId));

            return View(question);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateQuestionDetail(int questionId)
        {
            var question = await _quizDbContext.Questions.Include(x => x.Options)
                                                         .FirstOrDefaultAsync(x => x.QuestionId.Equals(questionId));

            return View(question);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuestionDetail(Questions question, IFormCollection form)
        {
            using(var transaction = await _quizDbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    _quizDbContext.Questions.Update(question);
                    await _quizDbContext.SaveChangesAsync();
                    var options = new List<Options>();
                    for (var i = 0; i < Convert.ToInt32(form["TotalOptionsCount"]); i++)
                    {
                        options.Add(new Options
                        {
                            OptionId = Convert.ToInt32(form[$"option[{i}].OptionId"]),
                            QuestionId = question.QuestionId,
                            OptionText = form[$"option[{i}].OptionText"],
                            IsCorrect = form[$"IsCorrect{i}"] == "true"
                        });
                    }
                    _quizDbContext.Options.UpdateRange(options);
                    await _quizDbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
                
            }
            

            return RedirectToAction("UpdateQuestionDetail", new {questionId = question.QuestionId});
        }
    }
}
