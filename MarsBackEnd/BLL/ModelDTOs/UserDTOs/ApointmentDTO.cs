using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ModelDTOs.UserDTOs
{
    public class ApointmentDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public PatientDTO Patient { get; set; }
        public DoctorDTO doctor { get; set; }
        public OfficeDTO office { get; set; }
        public DateTime MeetingTime { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
