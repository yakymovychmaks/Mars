using DLL.Models.AdminsModel;

namespace MarsBackEnd.Models.Admin
{
    public class AdminAPIModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //public adminapimodel(int id, string username, string email, string passwrd)
        //{
        //    id = id;
        //    username = username;
        //    email = email;
        //    password = passwrd;
        //}
        //public List<PostsAPIModel>? PostsOnSite { get; set; }
    }
}
