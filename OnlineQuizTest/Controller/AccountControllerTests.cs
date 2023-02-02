namespace OnlineQuizTest.Controller
{
    using System.Diagnostics.CodeAnalysis;
    using System.Security.Claims;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.QualityTools.Testing.Fakes.Stubs;
    using Moq;
    using OnlineQuiz.Controllers;
    using OnlineQuiz.DAL;
    using OnlineQuiz.Models;

    public class AccountControllerTests
    {
        private readonly AccountController _accountController;
        private readonly Mock<IAccountDAL> _accountDAOMock;

        public AccountControllerTests()
        {
            _accountDAOMock = new Mock<IAccountDAL>();
            _accountController = new AccountController(_accountDAOMock.Object);
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
        public async Task Login_Post_ReturnAccessDeniedViewResult_GivenInvalidUser()
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
                UserRoleId = (int)UserRole.User
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
            _accountDAOMock.Setup(x => x.CreateUser(model)).Throws(new Exception("Test exception"));

            var result = _accountController.Register(model) as ViewResult;
            var errorViewModel = result.Model as ErrorViewModel;

            Assert.Equal("Error", result.ViewName);
            Assert.Equal("Test exception", errorViewModel.ErrorDescription);
            _accountDAOMock.Verify(x => x.CreateUser(It.IsAny<UserRegisterModel>()), Times.Once());
        }
    }
}