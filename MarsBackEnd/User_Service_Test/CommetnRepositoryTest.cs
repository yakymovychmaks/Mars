using DLL.DataAccess;
using DLL.Repository;
using DLL.Model.UserModel;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;

namespace User_Service_Test
{
    [TestFixture]
    public class CommetnRepositoryTest
    {
        DbContextOptions<ApplicationDbContext> options;
        CommentRepository _CommentReporitory;
        Comment comment;
        [SetUp] public void SetUp()
        {
            options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MArsIndustrys;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
                .Options;
            comment = new Comment
            {
                Id = 1,
                Description = "Test",
                UserId = 1,
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
                }
            };
            _CommentReporitory = new CommentRepository(new ApplicationDbContext(options));
        }
        [Test, Order(1)]
        public void Add_ValidComment_AddCommentAndReturnSuccessMessage()
        {
            using(var dbContext = new ApplicationDbContext(options))
            {
                var result = _CommentReporitory.Add(comment);
                dbContext.SaveChanges();
                Assert.AreEqual("Comment was added", result);
            }
        }
        [Test, Order(2)]
        public void GetBuId_ValidComment_GetBuIdCommentAndReturnSuccessMessage()
        {
            using( var dbContext = new ApplicationDbContext(options))
            {
                var result = _CommentReporitory.GetById(comment.Id);
                Assert.AreEqual(comment.ToString(), result.ToString());
            }
        }
        [Test, Order(3)]
        public void Update_ValidComment_UpdateCommentAndReturnSuccessMessage()
        {
            using(var dbContext = new ApplicationDbContext(options))
            {
                var result = _CommentReporitory.Update(comment);
                dbContext.SaveChanges();
                Assert.AreEqual("It was update", result);
            }
        }
        [Test, Order(4)]
        public void Delete_ValidComment_DeleteCommentAndReturnSuccessMessage()
        {
            using(var dbContext = new ApplicationDbContext(options))
            {
                var result = _CommentReporitory.Delete(comment.Id);
                dbContext.SaveChanges();
                Assert.AreEqual("Delete was succesfull", result);
            }
        }
    }
}
