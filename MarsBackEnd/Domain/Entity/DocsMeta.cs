using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class DocsMeta
    {
        public int Id { get; set; } 
        public string FileName { get; set; }
        public string ContentTipe { get; set; }
        public int FileSize { get; set; }
        public DateOnly UploadDate { get; set; }
        public string PathFile { get; set; }
        public string NameHolder { get; set; }
    }
}
