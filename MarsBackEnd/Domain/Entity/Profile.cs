using Domain.Enum;
using Domain.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public int ApointmentId { get; set; }

        // Навігаційна властивість до сутності Profile
        [ForeignKey("ApointmentId")]
        public ICollection<Apointment> Apointment { get; set; }

    }
}
