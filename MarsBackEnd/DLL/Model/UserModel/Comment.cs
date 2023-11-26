using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Model.UserModel
{
    public class Comment
    {

 
            public int Id { get; set; }
            public string Description { get; set; }
            // Інші властивості для коментаря

            [ForeignKey("UserId")]
            public int UserId { get; set; }
            public User User { get; set; }

    }
}
