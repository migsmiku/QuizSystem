namespace OnlineQuiz.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using OnlineQuiz.DbContext;
    using OnlineQuiz.Models;

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

        [HttpGet("ViewQuizResult")]
        public IActionResult ViewQuizResults(int pageNumber = 1, int pageSize = 20)
        {
            int totalRecords = _quizDbContext.QuizSubmissions.Count();
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            AdminViewModel adminViewModel = new()
            {
                TotalRecords = totalRecords,
                TotalPages = totalPages,
                PageNumber = pageNumber,
                QuizSubmissions = _quizDbContext.QuizSubmissions.AsNoTracking()
                                                                           .Include(x => x.Quizzes)
                                                                           .ThenInclude(q => q.QuizQuestions)
                                                                           .Include(u => u.Users).OrderByDescending(x => x.EndTime)
                                                                           .Skip((pageNumber - 1) * pageSize)
                                                                           .Take(pageSize)
            };
            return View(adminViewModel);
        }

        [HttpGet("QuizResult/{pageNumber}")]
        public IActionResult QuizResult(int pageNumber = 1, int pageSize = 20)
        {
            int totalRecords = _quizDbContext.QuizSubmissions.Count();
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            AdminViewModel adminViewModel = new()
            {
                TotalRecords = totalRecords,
                TotalPages = totalPages,
                PageNumber = pageNumber,
                QuizSubmissions = _quizDbContext.QuizSubmissions.AsNoTracking()
                                                                           .Include(x => x.Quizzes)
                                                                           .ThenInclude(q => q.QuizQuestions)
                                                                           .Include(u => u.Users).OrderByDescending(x => x.EndTime)
                                                                           .Skip((pageNumber - 1) * pageSize)
                                                                           .Take(pageSize)
            };
            return View(adminViewModel);
        }

        public IActionResult ViewUserProfile()
        {
            return View();
        }

        public IActionResult EditQuestions()
        {
            return View();
        }
    }
}
