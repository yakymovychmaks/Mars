namespace DLL.Models.AdminsModel
{
    public class Admin
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Posts> PostsOnSite { get; set; }
    }
}
