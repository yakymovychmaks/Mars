using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ModelDTOs.AdminDTOs
{
    public class AdminDTO
    {
        public int Id { get; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //public List<PostsDTO>? PostsOnSite { get; set; }
    }
}
