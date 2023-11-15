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
    public class PatientService : IService<PatientDTO>
    {
        private PatientRepository _patientRepository;
        private IMapper _mapper;
        public void SetRepository(PatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }
        public IEnumerable<PatientDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<PatientDTO>>(_patientRepository.GetAll());
        }

        public PatientDTO GetById(int id)
        {
            if (id != null)
            {
                if (_patientRepository.GetById(id) != null)
                {
                    return _mapper.Map<PatientDTO>(_patientRepository.GetById(id));
                }
                else return null;

            }
            else return null;
        }
    }
}
