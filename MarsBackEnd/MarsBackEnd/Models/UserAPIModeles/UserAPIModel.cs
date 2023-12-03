using BLL.ModelDTOs.UserDTOs;
using DLL.Model.UserModel;

namespace MarsBackEnd.Models.UserAPIModeles
{
    public class UserAPIModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
        public string ProfilePicture { get; set; }
        public List<PostsAPIModel>? PostsDTO { get; set; }
        public List<ApointmentAPIModel>? ApointmentsDTO { get; set; }
        public List<CommentAPImodel>? CommentsDTO { get; set; }
    }
}
