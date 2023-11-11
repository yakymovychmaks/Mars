using System.Drawing.Printing;

namespace MarsBackEnd.Models.UserModel
{
    public class Patient
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ProfilePictire { get; set; }
        public List<Apointment> apointments { get; set; }
        public string MedicineHistory { get; set; }

    }
}
