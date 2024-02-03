using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Partner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Photo photo { get; set; }
        public string HrefMedia { get; set; }
    }
}
