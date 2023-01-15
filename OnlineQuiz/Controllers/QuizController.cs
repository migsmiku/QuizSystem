namespace OnlineQuiz.Controllers
{
    using System.Security.Claims;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using OnlineQuiz.DAL;
    using OnlineQuiz.Models;

    [Authorize]
    public class QuizController : Controller
    {
        private readonly IQuizDAL _quizDao;

        public QuizController(IQuizDAL quizDao)
        {
            _quizDao = quizDao;
        }

        public ActionResult ChooseQuizCategory()
        {
            IEnumerable<QuizCategory> quizCategory = _quizDao.GetQuizCategory();
            return View(quizCategory);
        }

        public ActionResult StartQuiz(int quizCategoryId, string quizCategoryName)
        {
            int? quizId = HttpContext.Session.GetInt32("quizId");
            QuizViewModel quizViewModel = new();
            if (quizId is null)
            {
                string quizName = quizCategoryName + " for " + User.FindFirst(ClaimTypes.Name)?.Value;
                int userId = Convert.ToInt32(User.FindFirst(ClaimTypes.Sid)?.Value);
                quizViewModel = _quizDao.CreateQuiz(quizCategoryId, quizName, userId);
                _ = quizViewModel.Questions.OrderBy(x => x.QuestionId);
                HttpContext.Session.SetInt32("quizId", quizViewModel.QuizId);
            }
            else
            {
                quizViewModel = _quizDao.GetQuizViewModel(quizId);
                _ = quizViewModel.Questions.OrderBy(x => x.QuestionId);
            }

            return View(quizViewModel);
        }

        public ActionResult Index()
        {
            return Redirect("/");
        }

        [HttpGet]
        public ActionResult SubmitQuiz(int quizId)
        {
            var quizViewModel = _quizDao.GetQuizViewModel(quizId);
            quizViewModel.UserName = User.FindFirst(ClaimTypes.Name)?.Value;
            _ = quizViewModel.Questions.OrderBy(x => x.QuestionId);
            return View("SubmitQuiz", quizViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitQuiz(IFormCollection form)
        {
            if (form == null)
            {
                return Redirect("/");
            }

            int? quizId = HttpContext.Session.GetInt32("quizId");
            var quizQuestions = new List<QuizQuestions>();
            for(var i = 0; i < Convert.ToInt32(form["totalQuestions"]); i++)
            {
                quizQuestions.Add(new QuizQuestions()
                {
                    QuizId= quizId.HasValue?quizId.Value:0,
                    QuestionId = Convert.ToInt32(form[$"Questions[{i}].QuestionId"]),
                    SelectedOptionId = Convert.ToInt32(form[$"selectedOptionId_{i}"]),
                });
            }
            var EndTime = DateTime.Now;
            var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.Sid)?.Value);
            _quizDao.SubmitQuiz(quizId, userId, quizQuestions, EndTime);

            HttpContext.Session.Clear();
            return RedirectToAction("SubmitQuiz","Quiz", quizId);
        }
    }
}
