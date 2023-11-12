using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ModelDTOs.UserDTOs
{
    public class DoctorDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Job { get; set; }
        public DateTime DAteOfBirth { get; set; }
        public string ProfilePicture { get; set; }
        public List<ApointmentDTO> Apointment { get; set; }
    }
}
