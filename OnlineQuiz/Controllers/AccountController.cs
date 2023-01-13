namespace OnlineQuiz.Controllers
{
    using System.Diagnostics;
    using System.Security.Claims;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using OnlineQuiz.DAO;
    using OnlineQuiz.Models;

    public class AccountController : Controller
    {
        private readonly IAccountDAO _accountDAO;

        public AccountController(IAccountDAO accountDAO)
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
        public async Task<IActionResult> Login(User user)
        {
            if (!ModelState.IsValid) { return View(); }

            if (LoginSucess(user.UserName, user.Password))
            {
                List<Claim> claims = new()
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(ClaimTypes.Email,"Test@test.com")
                };
                ClaimsIdentity identity = new(claims, "Cookie");
                ClaimsPrincipal principal = new(identity);

                await HttpContext.SignInAsync(principal);
                return Redirect("/");
            }

            return View();
        }

        private bool LoginSucess(string username, string password)
        {
            return _accountDAO.Login(username, password);
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
            if (!ModelState.IsValid) { Redirect("/Home/Index"); }
            if (user == null) { return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }); }
            user.UserRoleId = (int)UserRole.User;
            try
            {
                _accountDAO.CreateUser(user);
            }catch(Exception ex)
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
