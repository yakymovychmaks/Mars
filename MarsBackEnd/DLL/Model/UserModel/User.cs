using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Model.UserModel
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
        public string ProfilePicture { get; set; }

        [InverseProperty("User")]
        public List<Post>? Posts { get; set; }

        [InverseProperty("User")]
        public List<Apointment>? Apointments { get; set; }

        [InverseProperty("User")]
        public List<Comment>? Comments { get; set; }
    }
}
