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
                return "Delete was succesfull" + removeObj.FullName;
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
                var user = new User
                {
                    Id = 1,
                    FullName = "John Doe",
                    Email = "john1",
                    Password = "password123",
                    UserRole = "User",
                    ProfilePicture = "profile.jpg",
                    Posts = new List<Post>(),
                    Apointments = new List<Apointment>(),
                    Comments = new List<Comment>()
                };
                var rezult = _dbContext.Users.Find(user.Id);
                if (rezult == null)
                    return "it's null";
                rezult.UserRole = user.UserRole;
                rezult.Password = user.Password;
                rezult.Email = user .Email;
                rezult.FullName = user .FullName;
                rezult.Apointments = user.Apointments;
                rezult.Comments = user.Comments;
                rezult.Posts = user.Posts;
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
