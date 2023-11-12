using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ModelDTOs.UserDTOs
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ProfilePictire { get; set; }
        public List<ApointmentDTO> Apointments { get; set; }
        public string MedicineHistory { get; set; }
    }
}
