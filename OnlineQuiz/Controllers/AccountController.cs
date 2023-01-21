namespace OnlineQuiz.Controllers
{
    using System.Diagnostics;
    using System.Security.Claims;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Mvc;
    using OnlineQuiz.DAL;
    using OnlineQuiz.DbContext;
    using OnlineQuiz.Models;
    using OnlineQuiz.Models.Enum;

    public class AccountController : Controller
    {
        private readonly IAccountDAL _accountDAO;
        private readonly QuizDbContext _quizDbContext;

        public AccountController(IAccountDAL accountDAO, QuizDbContext quizDbContext)
        {
            _accountDAO = accountDAO;
            _quizDbContext = quizDbContext;
        }

        public IActionResult Index()
        {
            return Redirect("/");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Users user)
        {
            user = _accountDAO.Login(user.UserName, user.Password);
            if (!ModelState.IsValid || user is null) { return View("AccessDenied"); }
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Sid, user.UserID.ToString()),
                new Claim(ClaimTypes.NameIdentifier,user.UserName),
                new Claim(ClaimTypes.Name,user.FirstName+' '+user.LastName),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,((UserRole)user.UserRoleId).ToString()),
                new Claim("Admin",((UserRole)user.UserRoleId == UserRole.Admin).ToString())
            };
            ClaimsIdentity identity = new(claims, "Cookie");
            ClaimsPrincipal principal = new(identity);

            await HttpContext.SignInAsync(principal);
            return (UserRole)user.UserRoleId == UserRole.Admin ? RedirectToAction("Index", "Admin") : RedirectToAction("ChooseQuizCategory", "Quiz");
        }

        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("Cookie");
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterModel user)
        {
            if (!ModelState.IsValid) { return RedirectToAction("Index"); }
            if (user == null) { return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }); }
            user.UserRoleId = (int)UserRole.User;
            var newUser = new Users()
            {
                UserName= user.UserName,
                UserRoleId= user.UserRoleId,
                FirstName= user.FirstName,
                LastName= user.LastName,
                DateOfBirth= user.DateOfBirth,
                Email= user.Email,
                Address= user.Address,
                Password= user.Password,
                Phone= user.Phone,
            };
            try
            {
                _quizDbContext.Users.Add(newUser);
                _quizDbContext.SaveChanges();
                //_accountDAO.CreateUser(user);
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#else
                return View("Error", new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    ErrorDescription = ex.Message                 
                });
#endif
            }
            return Redirect("/");
        }
    }
}
