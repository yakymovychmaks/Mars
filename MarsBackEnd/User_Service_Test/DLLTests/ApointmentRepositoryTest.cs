using DLL.DataAccess;
using DLL.Repository;
using DLL.Model.UserModel;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;

namespace User_Service_Test.DLLTests
{
    [TestFixture]
    public class ApointmentRepositoryTest
    {
        DbContextOptions<ApplicationDbContext> options;
        ApointmentRepository _ApointmentReporitory;
        [SetUp]
        public void SetUp()
        {
            options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MArsIndustrys;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
                .Options;
            apointment = new Apointment
            {
                Id = 1,
                Title = "Test",
                Description = "Test",
                time = DateTime.Now,
                UserId = 3,
                user = new User
                {
                    Id = 3,
                    FullName = "John Doe",
                    Email = "john.doe@example.com",
                    Password = "password123",
                    UserRole = "User",
                    ProfilePicture = "profile.jpg",
                    Posts = new List<Post>(),
                    Apointments = new List<Apointment>(),
                    Comments = new List<Comment>()
                }
            };
            _ApointmentReporitory = new ApointmentRepository(new ApplicationDbContext(options));
        }
        [Test, Order(1)]
        public void Add_ValidApointment_AddApointmentAndReturnSuccessMessage()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                var result = _ApointmentReporitory.Add(apointment);
                dbContext.SaveChanges();
                Assert.AreEqual("Apointment was added", result);
            }
        }
        [Test, Order(2)]
        public void GetBuId_ValidApointment_GetBuIdApointmentAndRetusrnSuccessMessage()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                var result = _ApointmentReporitory.GetById(apointment.Id);
                dbContext.SaveChanges();
                Assert.AreEqual(apointment.ToString(), result.ToString());
            }
        }
        [Test, Order(3)]
        public void Update_ValidApointment_UpdateApointmentAndReturnSuccessMessage()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                apointment.Title = "new title";
                var result = _ApointmentReporitory.Update(apointment);
                dbContext.SaveChanges();
                Assert.AreEqual("It was update", result);
            }
        }
    }
}
