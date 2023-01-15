namespace OnlineQuiz.Controllers
{
    using System.Security.Claims;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using OnlineQuiz.DAL;
    using OnlineQuiz.Models;

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
                _ = quizViewModel.Questions.OrderBy(x => x);
                HttpContext.Session.SetInt32("quizId", quizViewModel.QuizId);
            }
            else
            {
                quizViewModel = _quizDao.GetQuizViewModel(quizId);
            }

            return View(quizViewModel);
        }

        public ActionResult Index()
        {
            return Redirect("/");
        }

        [HttpPost]
        public ActionResult SubmitQuiz(IFormCollection form)
        {
            return View();
        }
    }
}
