using Domain.Enum;
using Domain.Entity;

namespace Domain.Entity
{
    public class Profiles
    {
        public long Id { get; set; }

        public byte Age { get; set; }

        public string Address { get; set; }

        public long UserId { get; set; }

        public User User { get; set; }
        public List<Apointment>? Apointments { get; set; }
    }
}
