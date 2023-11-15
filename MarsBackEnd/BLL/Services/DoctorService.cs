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
    public class DoctorService : IService<DoctorDTO>
    {
        private DoctorRepository _doctorRepository;
        private IMapper _mapper;
        public void SetRepositories(DoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }
        public IEnumerable<DoctorDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<DoctorDTO>>(_doctorRepository.GetAll());
        }

        public DoctorDTO? GetById(int id)
        {
            if(id != 0)
            {
                if (_doctorRepository.GetById(id) != null)
                {
                    return _mapper.Map<DoctorDTO>(_doctorRepository.GetById(id));
                }
                else return null;
            }else return null;
        }
    }
}
