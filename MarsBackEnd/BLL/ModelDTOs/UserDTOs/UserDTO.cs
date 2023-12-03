using DLL.Model.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ModelDTOs.UserDTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
        public string ProfilePicture { get; set; }
        public List<PostDTO>? PostsDTO { get; set; }
        public List<ApointmentDTO>? ApointmentsDTO { get; set; }
        public List<CommentDTO>? CommentsDTO { get; set; }
    }
}
