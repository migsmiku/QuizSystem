namespace OnlineQuiz.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using OnlineQuiz.DbContext;
    using OnlineQuiz.Models;
    using static System.Net.WebRequestMethods;

    [Route("/api")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly QuizDbContext _quizDbContext;

        public ApiController(QuizDbContext quizDbContext)
        {
            _quizDbContext = quizDbContext;
        }

        public IActionResult Index()
        {
            return Ok();
        }
        //[HttpGet("QuizResults/{pageNumber}")]
        //public IActionResult QuizResults(int pageNumber, int pageSize = 20)
        //{
        //    int totalRecords = _quizDbContext.QuizSubmissions.Count();
        //    int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
        //    AdminViewModel adminViewModel = new()
        //    {
        //        TotalRecords = totalRecords,
        //        TotalPages = totalPages,
        //        PageNumber = pageNumber,
        //        QuizSubmissions = _quizDbContext.QuizSubmissions.AsNoTracking()
        //                                                                   .Include(x => x.Quizzes)
        //                                                                   .ThenInclude(q => q.QuizQuestions)
        //                                                                   .Include(u => u.Users).OrderByDescending(x => x.EndTime)
        //                                                                   .Skip((pageNumber - 1) * pageSize)
        //                                                                   .Take(pageSize)
        //    };
        //    Http.RenderPartial
        //    return PartialViewResult("_QuizResultPartial", adminViewModel);
        //}

    }
}
