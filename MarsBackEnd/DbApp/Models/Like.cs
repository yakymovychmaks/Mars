using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbApp.Models
{
    public class Like
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Post Post { get; set; }
    }
}
