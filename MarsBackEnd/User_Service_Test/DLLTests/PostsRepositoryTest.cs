using DLL.DataAccess;
using DLL.Repository;
using DLL.Model.UserModel;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;

namespace User_Service_Test
{
    [TestFixture]
    public class PostsRepositoryTest
    {
        DbContextOptions<ApplicationDbContext> options;
        PostRepository _PostReporitory;
        Post post;
        [SetUp]
        public void SetUp()
        {
            options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MArsIndustrys;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
                .Options;
            post = new Post
            {
                Id = 2,
                title = "Title",
                Description = "Description",
                UserId = 2,
                user = new User
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
                }
        };
            _PostReporitory = new PostRepository(new ApplicationDbContext(options));

        }
        [Test, Order(1)]
        public void Add_Validpost_AddPostAndReturnSuccessNessage()
        {
            using (var dbContext = new ApplicationDbContext(options))
            {
                var result = _PostReporitory.Add(post);
                dbContext.SaveChanges();
                Assert.AreEqual("Post was added", result);
            }
        }
        [Test,Order(2)]
        public void Update_ValidPost_UpdatePostAndReturnSuccessMessage()
        {
            using(var dbContext = new ApplicationDbContext(options))
            {
                post.title = "New Title";
                var rezult = _PostReporitory.Update(post);
                dbContext.SaveChanges();
                Assert.AreEqual("It was update",rezult.ToString());
            }
        }
        [Test,Order(3)]
        public void GetBuId_ValidPost_GetBuIdPosyAndReturnSeccessMessage()
        {
            using( var dbContext = new ApplicationDbContext(options))
            {
                var result = _PostReporitory.GetById(post.Id);
                dbContext.SaveChanges();
                Assert.AreEqual(post.ToString(), result.ToString());
            }
        }
        [Test, Order(4)]
        public void Delete_ValidPost_DeletePostAndReturnSeccessMessage()
        {
            using(var dbContext = new ApplicationDbContext(options))
            {
                var result = _PostReporitory.Delete(post.Id);
                dbContext.SaveChanges();
                Assert.AreEqual("Delete was succesfull", result);
            }
        }
    }
}
