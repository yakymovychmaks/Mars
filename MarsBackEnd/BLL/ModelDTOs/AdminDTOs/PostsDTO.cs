using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ModelDTOs.AdminDTOs
{
    public class PostsDTO
    {
        public int Id { get; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Photo { get; set; }
        public DateTime CreateAt { get; set; }
        public AdminDTO Author { get; set; }
    }
}
