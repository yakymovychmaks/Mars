using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class PatientWaitList
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Gmail { get; set; }
        public List<ThemesQuestion> thems { get; set; }
        public string Message {  get; set; }
    }
}
