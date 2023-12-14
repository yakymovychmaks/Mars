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
        [Test]
        public void Update_ValidUser_UpdatesUserAndReturnsSuccessMessage()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MArsIndustrys;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
                .Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                var userRepository = new UserReposiyory(dbContext);
                
                var user = new User
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
                userRepository.Add(user);
                // Act
                var result = userRepository.Update(user);

                // Assert
                Assert.AreEqual("it's update", result);
                dbContext.SaveChanges(); // Ensure changes are saved to the in-memory database
            }
        }

        [Test]
        public void Update_ExceptionThrown_ReturnsErrorMessage()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MArsIndustrys;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
                .Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                var userRepository = new UserReposiyory(dbContext);

                var user = new User
                {
                    Id = 2,
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
                var result = userRepository.Update(user);

                // Assert
                Assert.AreEqual("it's null", result);
            }
        }
    }
}
