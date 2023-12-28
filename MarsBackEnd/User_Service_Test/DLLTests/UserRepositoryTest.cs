using DLL.DataAccess;
using DLL.Repository;
using DLL.Model.UserModel;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;

namespace User_Service_Test.DLLTests
{
    [TestFixture]
    public class UserRepositoryTest
    {
        public DbContextOptions<ApplicationDbContext> options;
        public UserRepository _UserRepository;
        public User user;

        [SetUp]
        public void SetUp()
        {
            user = new User
            {
                Id = 1,
                FullName = "John Doe",
                Email = "john.doe@example.com",
                Password = "password123",
                UserRole = "User",
                ProfilePicture = "profile.jpg",
                Posts = new List<Post>(),
                Apointments = new List<Apointment>(),
                Comments = new List<Comment>()
            };
            options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MArsIndustrys;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
                .Options;
            _UserRepository = new UserRepository(new ApplicationDbContext(options));
        }
        [Test, Order(1)]
        public void Add_ValidUser_AddUserAndReturnSuccessMessage()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {

                _UserRepository.Add(user);
                var result = _UserRepository.GetById(user.Id);
                Assert.AreEqual(user, result);
                dbContext.SaveChanges();
            }
        }
        [Test, Order(2)]
        public void Update_ValidUser_UpdatesUserAndReturnsSuccessMessage()
        {
            // Arrange


            using (var dbContext = new ApplicationDbContext(options))
            {
                // Act
                user.FullName = "Test";
                _UserRepository.Update(user);
                var result = _UserRepository.GetById(user.Id);
                // Assert
                Assert.AreEqual(user.ToString(), result.ToString());
                dbContext.SaveChanges(); // Ensure changes are saved to the in-memory database
            }
        }

        [Test, Order(3)]
        public void Update_ExceptionThrown_ReturnsErrorMessage()
        {
            // Arrange


            using (var dbContext = new ApplicationDbContext(options))
            {


                var wrongUser = new User
                {
                    Id = -1,
                    FullName = "John Doe",
                    Email = "john.doe@example.com",
                    Password = "password123",
                    UserRole = "User",
                    ProfilePicture = "profile.jpg",
                    Posts = new List<Post>(),
                    Apointments = new List<Apointment>(),
                    Comments = new List<Comment>()
                };

                // Force an exception when saving changes
                dbContext.SaveChanges(); // This will throw an exception

                // Act
                var result = _UserRepository.Update(wrongUser);

                // Assert
                Assert.AreEqual("it's null", result);
            }
        }
        [Test, Order(4)]
        public void Delete_ValidUser_DeleteAndReturnSuccesssMessage()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {

                var result = _UserRepository.Delete(user.Id);
                dbContext.SaveChanges();
                Assert.AreEqual("Delete was succesfull", result.ToString());
            }
        }
    }
}
