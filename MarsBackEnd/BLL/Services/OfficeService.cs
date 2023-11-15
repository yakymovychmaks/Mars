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
    public class OfficeService : IService<OfficeDTO>
    {
        private OfficeRepository _officeRepository;
        private IMapper _mapper;
        public void SetRepository(OfficeRepository officeRepository, IMapper mapper)
        {
            _officeRepository = officeRepository;
            _mapper = mapper;
        }
        public IEnumerable<OfficeDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<OfficeDTO>>(_officeRepository.GetAll());
        }

        public OfficeDTO? GetById(int id)
        {
            if (id != 0)
            {
                if(_officeRepository.GetById(id) != null)
                {
                    return _mapper.Map<OfficeDTO>(_officeRepository.GetById(id));
                }
            }
            return null;
        }
    }
}
