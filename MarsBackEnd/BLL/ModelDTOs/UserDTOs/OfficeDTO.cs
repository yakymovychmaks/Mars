using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ModelDTOs.UserDTOs
{
    public class OfficeDTO
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public List<ApointmentDTO> Apointment { get; set; }
    }
}
