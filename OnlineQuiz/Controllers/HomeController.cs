namespace OnlineQuiz.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using OnlineQuiz.DAL;
    using OnlineQuiz.Models;


    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFeedbackDAL _feedbackDAL;

        public HomeController(ILogger<HomeController> logger, IFeedbackDAL feedbackDAL)
        {
            _logger = logger;
            _feedbackDAL = feedbackDAL;
        }

        [Authorize]
        public IActionResult Index()
        {
            return RedirectToAction("ChooseQuizCategory", "Quiz");
        }

        public IActionResult Feedback()
        {
            return View("Feedback");
        }

        [HttpPost]
        public IActionResult SubmitFeedback(IFormCollection form)
        {
            if (ModelState.IsValid)
            {
                var rowInserted = _feedbackDAL.SaveFeedback(Convert.ToInt32(form["rating"]), form["FeedbackText"]);
                if(rowInserted!= 1) { throw new Exception("Insert Feedback failed"); }
            }
            return View("FeedbackSubmitted");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}