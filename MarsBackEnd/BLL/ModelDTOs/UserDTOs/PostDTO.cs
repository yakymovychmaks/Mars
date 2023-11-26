using DLL.Model.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ModelDTOs.UserDTOs
{
    public class PostDTO
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string Description { get; set; }
        // Інші властивості для поста
        public int UserId { get; set; }
        public UserDTO UserDTO { get; set; }
    }
}
