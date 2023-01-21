namespace OnlineQuiz.Controllers
{
    using System.Diagnostics;
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

        //[HttpGet("Admin/ViewQuizResult")]
        //public IActionResult ViewQuizResult([FromQuery]int pageNumber = 1, int pageSize = 20)
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
        //    return View(adminViewModel);
        //}

        //[HttpPost]
        public IActionResult ViewQuizResult(IFormCollection form, string categoryFilter, string userFilter, int pageNumber = 1, int pageSize = 20)
        {
            var quizSubmissions = _quizDbContext.QuizSubmissions.AsNoTracking()
                                                                           .Include(x => x.Quizzes)
                                                                           .ThenInclude(q => q.QuizQuestions)
                                                                           .Where(x => categoryFilter == null || x.Quizzes.QuizCategories.QuizCategoryName == ((QuizCategory)Enum.Parse(typeof(QuizCategory), categoryFilter)).ToDescription())
                                                                           .Include(u => u.Users)
                                                                           .Where(u => userFilter == null || u.UserId == Convert.ToInt32(userFilter))
                                                                           .OrderByDescending(x => x.EndTime);
            int totalRecords = quizSubmissions.Count();
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            AdminViewModel adminViewModel = new()
            {
                TotalRecords = totalRecords,
                TotalPages = totalPages,
                PageNumber = pageNumber,
                CategoryFilter = categoryFilter,
                UserFilter = userFilter,
                QuizSubmissions= quizSubmissions.Skip((pageNumber - 1) * pageSize)
                                                .Take(pageSize)
            };

            return View(adminViewModel);
        }

        //[HttpPost]
        //public IActionResult ViewQuizResult(IFormCollection form)
        //{
        //    int pageNumber = 1;
        //    int pageSize = 20;
        //    pageNumber = int.Parse(form["page-selector"]);
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
        //    return View(adminViewModel);
        //}

        [Route("Admin/ViewQuizResult/ViewUserProfile")]
        public async Task<IActionResult> ViewUserProfile([FromQuery]int userId)
        {
            var user = await _quizDbContext.Users.SingleOrDefaultAsync(x=>x.UserID.Equals(userId));
            if (user == null) { return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }); }
            return View("_ViewUserProfilePartial",user);
        }

        public IActionResult ViewAllUserProfile(int pageNumber = 1, int pageSize = 20)
        {
            var users = _quizDbContext.Users.AsNoTrackingWithIdentityResolution();
            if (users == null) { return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }); }
            int totalRecords = users.Count();
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            AdminViewModel adminViewModel = new()
            {
                TotalRecords = totalRecords,
                TotalPages = totalPages,
                PageNumber = pageNumber,
                Users= users
            };
                        
            return View(adminViewModel);
        }

        public async Task<ActionResult> ManageUserStatus(int userId, string status)
        {
            var user = _quizDbContext.Users.Single(x => x.UserID == userId);
            user.UserStatus = status == "Active";
            await _quizDbContext.SaveChangesAsync();
            return RedirectToAction("ViewAllUserProfile");
        }

        public IActionResult EditQuestions()
        {
            return View();
        }
    }
}
