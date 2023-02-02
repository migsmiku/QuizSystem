namespace OnlineQuizTest.DAL
{
    using System;
    using System.Transactions;
    using Microsoft.Data.SqlClient;
    using Microsoft.Extensions.Configuration;
    using Moq;
    using OnlineQuiz.DAL;
    using OnlineQuiz.Models;

    public class AccountDALTests
    {
        private readonly Mock<AccountDAL> _accountDAL;

        public AccountDALTests()
        {
            _accountDAL = new Mock<AccountDAL>();
        }

        [Fact]
        public void Login_ValidCredentials_ReturnsUser()
        {
            Users expectedUser = new Users { UserName = "testuser", FirstName = "Test", LastName = "User", Email = "testuser@example.com" };

            _accountDAL.Setup(x => x.Login("testuser", "password")).Returns(expectedUser);

            Users actualUser = _accountDAL.Object.Login("testuser", "password");

            Assert.NotNull(actualUser);
            Assert.Equal(expectedUser, actualUser);
        }
    }
}
