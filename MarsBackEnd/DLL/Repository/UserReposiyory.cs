using DLL.DataAccess;
using DLL.Interface;
using DLL.Model.UserModel;


namespace DLL.Repository
{
    public class UserReposiyory : IRepository<User>
    {
        private readonly ApplicationDbContext _dbContext;
        public UserReposiyory(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string Add(User entity)
        {
            try
            {
                _dbContext.Users.Add(entity);
                _dbContext.SaveChanges();
                return "User was added";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(int id)
        {
            try
            {
                var removeObj = _dbContext.Users.Find(id);
                if ( removeObj== null)
                {
                    return "Sorry wrong id";
                }
                _dbContext.Users.Remove(removeObj);
                _dbContext.SaveChanges();
                return "Delete was succesfull";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IEnumerable<User> GetAll()
        {
            try
            {
                return _dbContext.Users.ToList();
            }
            catch 
            {
                return new List<User>();
            }
        }

        public User GetById(int id)
        {
            try
            {
                return _dbContext.Users.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public string Update(User entity)
        {
            try
            {
                if (_dbContext.Users.Find(entity.Id) == null)
                    return "error: wrong user";
                _dbContext.Users.Update(entity);
                _dbContext.SaveChanges();
                return "it's update";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
