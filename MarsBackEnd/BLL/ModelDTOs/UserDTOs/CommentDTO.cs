using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ModelDTOs.UserDTOs
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        // Інші властивості для коментаря
        public int UserId { get; set; }
        public UserDTO User { get; set; }
    }
}
