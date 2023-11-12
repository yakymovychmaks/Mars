namespace DLL.Models.UserModel
{
    public class Apointment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public Office Office { get; set; }
        public DateTime MeetingTime { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
