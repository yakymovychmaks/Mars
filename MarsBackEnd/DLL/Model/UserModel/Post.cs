using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Model.UserModel
{
    public class Post
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string Description { get; set; }
        // Інші властивості для поста

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User user { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
