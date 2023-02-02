namespace OnlineQuizTest.Controller
{
    using System.Diagnostics.CodeAnalysis;
    using System.Security.Claims;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Routing;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.QualityTools.Testing.Fakes.Stubs;
    using Moq;
    using NSubstitute;
    using OnlineQuiz.Controllers;
    using OnlineQuiz.DAL;
    using OnlineQuiz.DbContext;
    using OnlineQuiz.Models;
    using OnlineQuiz.Models.Enum;
    using static OnlineQuizTest.Controller.AccountControllerTests;

    public class AccountControllerTests
    {
        private readonly AccountController _accountController;
        private readonly Mock<IAccountDAL> _accountDAOMock;
        private readonly Mock<QuizDbContext> _quizDbContextMock;
        private readonly Mock<HttpContext> _mockHttpContext;

        internal interface IQuizDbContext
        {
        }

        public AccountControllerTests()
        {
            IAuthenticationService authenticationService = Substitute.For<IAuthenticationService>();

            authenticationService
                .SignInAsync(Arg.Any<HttpContext>(), Arg.Any<string>(), Arg.Any<ClaimsPrincipal>(),
                    Arg.Any<AuthenticationProperties>()).Returns(Task.FromResult((object)null));

            var serviceProvider = Substitute.For<IServiceProvider>();
            //var authSchemaProvider = Substitute.For<IAuthenticationSchemeProvider>();
            //var systemClock = Substitute.For<ISystemClock>();

            //authSchemaProvider.GetDefaultAuthenticateSchemeAsync().Returns(Task.FromResult
            //(new AuthenticationScheme("idp", "idp",
            //    typeof(IAuthenticationHandler))));

            serviceProvider.GetService(typeof(IAuthenticationService)).Returns(authenticationService);
            //serviceProvider.GetService(typeof(ISystemClock)).Returns(systemClock);
            //serviceProvider.GetService(typeof(IAuthenticationSchemeProvider)).Returns(authSchemaProvider);

            var httpContext = Substitute.For<HttpContext>();
            //var session = Substitute.For<ISession>();
            //httpContext.Session.Returns(session);

            serviceProvider
                    .GetService(Arg.Is(typeof(ITempDataDictionaryFactory)))
                    .Returns(Substitute.For<ITempDataDictionaryFactory>());
            serviceProvider
                    .GetService(Arg.Is(typeof(IUrlHelperFactory)))
                    .Returns(Substitute.For<IUrlHelperFactory>());
            httpContext.RequestServices.Returns(serviceProvider);
            var controllerContext = new ControllerContext { HttpContext = httpContext };

            _quizDbContextMock = new Mock<QuizDbContext>();
            _mockHttpContext = new Mock<HttpContext>();
            _accountDAOMock = new Mock<IAccountDAL>();
            _accountController = new AccountController(_accountDAOMock.Object, _quizDbContextMock.Object);
            _accountController.ControllerContext = controllerContext;
        }

        [Fact]
        public void Index_ReturnRedirectResult()
        {
            var result = _accountController.Index();

            Assert.IsType<RedirectResult>(result);
            Assert.Equal("/", (result as RedirectResult).Url);
        }

        [Fact]
        public void Login_ReturnViewResult()
        {
            var result = _accountController.Login();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Login_Post_ReturnAccessDeniedViewResult_GivenInvalidUserAsync()
        {
            var user = new Users
            {
                UserName = "invlaid",
                Password = "invalid"
            };
            _accountDAOMock.Setup(x => x.Login(user.UserName, user.Password)).Returns(null as Users);

            var result = await _accountController.Login(user);

            Assert.IsType<ViewResult>(result);
            Assert.Equal("AccessDenied", (result as ViewResult).ViewName);
            _accountDAOMock.Verify(x => x.Login(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public async Task Login_Post_ReturnRedirectToActionResult_GivenValidUser()
        {
            var user = new Users
            {
                UserID = 1,
                UserName = "validUserName",
                Password = "validPassword",
                FirstName = "valid",
                LastName = "user",
                Email = "valid.user@test.com",
                UserRoleId = (int)UserRole.User,
                UserStatus = true
            };

            _accountDAOMock.Setup(a => a.Login(user.UserName, user.Password)).Returns(user);

            var result = await _accountController.Login(user);
            
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("ChooseQuizCategory", (result as RedirectToActionResult).ActionName);
            Assert.Equal("Quiz", (result as RedirectToActionResult).ControllerName);
        }


        [Fact]
        public void Register_ReturnsViewResult()
        {
            var result = _accountController.Register();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Register_InvalidModel_RedirectsToIndex()
        {
            var model = new UserRegisterModel { };

            _accountController.ModelState.AddModelError("Test", "Test error");

            var result = _accountController.Register(model) as RedirectResult;

            Assert.Equal("/Home/Index", result.Url);
            _accountDAOMock.Verify(x => x.CreateUser(It.IsAny<UserRegisterModel>()), Times.Never());
        }

        [Fact]
        public void Register_CreateUserThrowsException_ReturnsErrorView()
        {
            var model = new UserRegisterModel();

            var usersDbSetMock = new Mock<DbSet<Users>>();
            _quizDbContextMock.SetupGet(x => x.Users).Returns(usersDbSetMock.Object);
            usersDbSetMock.Setup(x => x.Add(new Users()));
            _quizDbContextMock.Setup(x => x.SaveChanges()).Throws(new Exception("Test exception"));

            var result = _accountController.Register(model) as ViewResult;
            var errorViewModel = result.Model as ErrorViewModel;

            Assert.Equal("Error", result.ViewName);
            Assert.Equal("Test exception", errorViewModel.ErrorDescription);
            _quizDbContextMock.Verify(x => x.SaveChanges(), Times.Once());
        }
    }
}