using AutoMapper;
using BLL.Interface;
using BLL.ModelDTOs.UserDTOs;
using DLL.Model.UserModel;
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
        public ApointmentRepository _apointmentRepository;
        public IMapper _mapper;
        public ApointmentService(ApointmentRepository apointmentRepository, IMapper mapper)
        {
            _apointmentRepository = apointmentRepository;
            _mapper = mapper;
        }

        public string Add(ApointmentDTO entity)
        {
            try
            {
                if(entity == null)
                {
                    return "can't be null";

                }
                return _apointmentRepository.Add(_mapper.Map<Apointment>(entity));
                
            }
            catch (Exception ex)
            {
                return "Exeption on the BLL layer"+ ex.Message;
            }
        }

        public string Delete(ApointmentDTO entity)
        {
            try
            {
                return _apointmentRepository.Delete(entity.Id);
            }
            catch (Exception ex)
            {
                return "Exeption on the BLL layer"+ ex.Message;
            }
        }

        public IEnumerable<ApointmentDTO> GetAll()
        {
            try
            {
                return _mapper.Map<IEnumerable<ApointmentDTO>>(_apointmentRepository.GetAll());
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<ApointmentDTO>();
            }
        }

        public ApointmentDTO GetById(int id)
        {
            try
            {
                return _mapper.Map<ApointmentDTO>(_apointmentRepository.GetById(id));
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string Update(ApointmentDTO entity)
        {
            try
            {
                return _apointmentRepository.Update(_mapper.Map<Apointment>(entity));
            }
            catch (Exception ex)
            {
                return "Exeption on the BLL layer" + ex.Message;
            }
        }
    }
}
