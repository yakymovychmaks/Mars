namespace MarsBackEnd.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ProfilePicture { get; set; }
        public string UserRole { get; set; }
        public List<Post> Posts { get; set; }
    }
}
