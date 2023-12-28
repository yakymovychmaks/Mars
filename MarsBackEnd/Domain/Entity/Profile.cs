using Domain.Enum;
using Domain.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class Profile
    {
        public int Id { get; set; }

        public byte Age { get; set; }

        public string Address { get; set; }

        [ForeignKey("UserId")]

        public int? UserId { get; set; }
        //public User? User { get; set; }
        public List<Apointment>? Apointments { get; set; }
    }
}
