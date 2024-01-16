using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interface;
using BLL.Services;
using DLL.Interface;
using Domain.Entity;
using Domain.Enum;
using Domain.Extensions;
using Domain.Helpers;
using Domain.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace User_Service_Test.BLLTests
{
    [TestFixture]
    public class UserServiceTest
    {
        private Mock<IRepository<Profiles>> _profilesRepositoryMock;
        private Mock<IRepository<User>> _userRepositoryMock;
        private ILogger<UserService> _logger;

        [SetUp]
        public void Setup()
        {
            _profilesRepositoryMock = new Mock<IRepository<Profiles>>();
            _userRepositoryMock = new Mock<IRepository<User>>();
            _logger = Mock.Of<ILogger<UserService>>();


        }

        [Test]
        public async Task Create_UserAlreadyExists_ReturnsUserAlreadyExistsResponse()
        {
            // Arrange
            var existingUser = new User { Name = "existingUser" };
            _userRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(new List<User>().AsQueryable());

            var userService = new UserService(_logger, _profilesRepositoryMock.Object, _userRepositoryMock.Object);
            var userModel = new User { Name = "existingUser" };

            // Act
            var result = await userService.Create(userModel);

            // Assert
            Assert.AreEqual(StatusCode.UserAlreadyExists, result.StatusCode);
            Assert.IsNull(result.Data);
            Assert.AreEqual("Користувач такий вже існує", result.Description);
        }

        [Test]
        public async Task Create_NewUser_CreatesUserAndProfile()
        {
            // Arrange
            _userRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(new List<User>());
            var userService = new UserService(_logger, _profilesRepositoryMock.Object, _userRepositoryMock.Object);
            var userModel = new User { Name = "newUser", Role = Role.User, Password = "password", Profile = new Profiles() };

            // Act
            var result = await userService.Create(userModel);

            // Assert
            _userRepositoryMock.Verify(x => x.Create(It.IsAny<User>()), Times.Once);
            _profilesRepositoryMock.Verify(x => x.Create(It.IsAny<Profiles>()), Times.Once);

            Assert.AreEqual(StatusCode.OK, result.StatusCode);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual("Користувача створено", result.Description);
        }

        // Додайте інші тести за аналогією з тестами вище.
    }
}
