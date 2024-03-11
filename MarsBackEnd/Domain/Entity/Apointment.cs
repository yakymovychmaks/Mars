using Domain.Enum;
using Domain.Entity;

namespace Domain.Entity
{
    public class Apointment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime time { get; set; }
        public int? ProfileId { get; set; }
        public Profile? Profile { get; set; }

        public User user { get; set; }
    }
}
