using DLL.DataAccess;
using DLL.Repository;
using DLL.Model.UserModel;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;

namespace User_Service_Test
{
    [TestFixture]
    public class UserServiceTests
    {
        DbContextOptions<ApplicationDbContext> options;
        UserReposiyory _UserRepository;
        User user;

        [SetUp] public void SetUp()
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
            _UserRepository = new UserReposiyory(new ApplicationDbContext(options));
        }
        [Test]
        public void Add_ValidUser_AddUserAndReturnSuccessMessage()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                var result = _UserRepository.Add(user);
                Assert.AreEqual("User was added", result);
                dbContext.SaveChanges();
            }
        }
        [Test]
        public void Update_ValidUser_UpdatesUserAndReturnsSuccessMessage()
        {
            // Arrange


            using (var dbContext = new ApplicationDbContext(options))
            {
                


                
                // Act
                var result = _UserRepository.Update(user);

                // Assert
                Assert.AreEqual("it's update", result);
                dbContext.SaveChanges(); // Ensure changes are saved to the in-memory database
            }
        }

        [Test]
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
    }
}
