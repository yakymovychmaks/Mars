using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Blog
    {
        public int Id { get; set; }
        public List<Tag> tags { get; set; }
        public List<Post> posts { get; set; }
    }
}
