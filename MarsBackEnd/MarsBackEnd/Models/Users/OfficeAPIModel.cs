using DLL.Models.UserModel;

namespace MarsBackEnd.Models.Users
{
    public class OfficeAPIModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public List<ApointmentAPIModel> ApointmentAPI { get; set; }
    }
}
