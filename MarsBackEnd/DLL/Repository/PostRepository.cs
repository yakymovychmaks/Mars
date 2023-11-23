using DLL.DataAccess;
using DLL.Interface;
using DLL.Models.AdminsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository
{
    public class PostRepository : IRepository<Posts>
    {
        private readonly ApplicationDbContext _DbContext;
        public PostRepository(ApplicationDbContext context)
        {
            _DbContext = context;
        }
        public void Add(Posts entity)
        {
            _DbContext.Posts.Add(entity);
            _DbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var postToDelete = _DbContext.Posts.Find(id);
            if (postToDelete != null)
            {
                _DbContext.Posts.Remove(postToDelete);
                _DbContext.SaveChanges();
            }
        }

        public IEnumerable<Posts> GetAll()
        {
            return _DbContext.Posts.ToList();
        }

        public Posts GetById(int id)
        {
            return _DbContext.Posts.Find(id);
        }

        public void Update(Posts entity)
        {
            _DbContext.Posts.Update(entity);
        }
    }
}
