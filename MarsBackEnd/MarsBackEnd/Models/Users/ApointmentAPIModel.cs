using DLL.Models.UserModel;

namespace MarsBackEnd.Models.Users
{
    public class ApointmentAPIModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public PatientAPIModel PatientAPI { get; set; }
        public DoctorAPIModel DoctorAPI { get; set; }
        public OfficeAPIModel OfficeAPI { get; set; }
        public DateTime MeetingTime { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
