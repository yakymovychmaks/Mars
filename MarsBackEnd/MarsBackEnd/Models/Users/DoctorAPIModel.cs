using DLL.Models.UserModel;

namespace MarsBackEnd.Models.Users
{
    public class DoctorAPIModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Job { get; set; }
        public DateTime DAteOfBirth { get; set; }
        public string ProfilePicture { get; set; }
        public List<ApointmentAPIModel> ApointmentAPI { get; set; }
    }
}
