using AutoMapper;
using BLL.Interface;
using BLL.ModelDTOs.UserDTOs;
using DLL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ApointmentService : IService<ApointmentDTO>
    {
        private ApointmentRepository _apointmentRepository;
        private IMapper _mapper;

        public IEnumerable<ApointmentDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<ApointmentDTO>>(_apointmentRepository.GetAll());
        }

        public ApointmentDTO? GetById(int id)
        {
            if (id != null)
            {
                if (_apointmentRepository != null)
                    return _mapper.Map<ApointmentDTO>(_apointmentRepository.GetById(id));
                else return null;
            }
            else return null;
        }

        public void SetRepositories(ApointmentRepository apointmentRepository, IMapper mapper)
        {
            _apointmentRepository = apointmentRepository;
            _mapper = mapper;
        }

    }
}
