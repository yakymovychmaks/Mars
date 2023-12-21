using DLL.Model.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DLL.Model.UserModel
{
    public class User
    {
            public long Id { get; set; }
            public string Password { get; set; }
            public string Name { get; set; }
            public Role Role { get; set; }
            public Profile Profile { get; set; }
            public List<Post>? Posts { get; set; }
        //public int Id { get; set; }
        //public string FullName { get; set; }
        //public string Email { get; set; }
        //public string Password { get; set; }
        //public string UserRole { get; set; }
        //public string ProfilePicture { get; set; }

        //public List<Post>? Posts { get; set; }

        //[InverseProperty("User")]
        //public List<Apointment>? Apointments { get; set; }

        //[InverseProperty("User")]
        //public List<Comment>? Comments { get; set; }
    }
}
