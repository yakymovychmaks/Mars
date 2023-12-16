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
                return "Exeption on DLL layer" + ex.Message;
            }
        }

        public string Delete(int id)
        {
            try
            {
                var removeObj = _dbContext.Users.Find(id);
                _dbContext.Users.Remove(removeObj);
                _dbContext.SaveChanges();
                return "Delete was succesfull";
            }
            catch (Exception ex)
            {
                return "Exeption on DLL layer" + ex.Message;
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
                var result = _dbContext.Users.Find(id);
                if (result == null)
                    throw new Exception("it's null");
                return result;
            }
            catch(Exception ex) 
            {
                throw new Exception("Sorry" + ex.Message);
            }
        }

        public string Update(User entity)
        {
            try
            {
                var rezult = _dbContext.Users.Find(entity.Id);
                if (rezult == null)
                    return "it's null";
                _dbContext.Entry(rezult).CurrentValues.SetValues(entity);
                _dbContext.SaveChanges();
                //_dbContext.Users.Update(entity);
                //_dbContext.SaveChanges();
                return "it's update";
            }
            catch (Exception ex)
            {
                return "Exception on DLL layer" + ex.Message;
            }
        }
    }
}
