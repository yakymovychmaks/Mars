using DLL.Model.UserModel;

namespace MarsBackEnd.Models.UserAPIModeles
{
    public class ApointmentAPIModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime MeetingTime { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
