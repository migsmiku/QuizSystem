namespace OnlineQuiz.Controllers
{
    using System.Diagnostics;
    using System.Security.Claims;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Mvc;
    using OnlineQuiz.DAL;
    using OnlineQuiz.Models;

    public class AccountController : Controller
    {
        private readonly IAccountDAL _accountDAO;

        public AccountController(IAccountDAL accountDAO)
        {
            _accountDAO = accountDAO;
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
                new Claim("Admin",(user.UserRoleId == 1).ToString())
            };
            ClaimsIdentity identity = new(claims, "Cookie");
            ClaimsPrincipal principal = new(identity);

            await HttpContext.SignInAsync(principal);
            return RedirectToAction("ChooseQuizCategory", "Quiz");
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
            if (!ModelState.IsValid) { _ = Redirect("/Home/Index"); }
            if (user == null) { return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }); }
            user.UserRoleId = (int)UserRole.User;
            try
            {
                _accountDAO.CreateUser(user);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                    ErrorDescription = ex.Message
                });
            }
            return Redirect("/");
        }
    }
}
