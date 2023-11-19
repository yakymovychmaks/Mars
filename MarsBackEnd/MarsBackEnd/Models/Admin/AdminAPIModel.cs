using DLL.Models.AdminsModel;

namespace MarsBackEnd.Models.Admin
{
    public class AdminAPIModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<PostsAPIModel> PostsOnSite { get; set; }
    }
}
