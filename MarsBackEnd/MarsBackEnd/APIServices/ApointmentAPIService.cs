using AutoMapper;
using BLL.ModelDTOs.UserDTOs;
using BLL.Services;
using MarsBackEnd.Models.UserAPIModeles;
using Newtonsoft.Json;

namespace MarsBackEnd.APIServices
{
    public class ApointmentAPIService
    {
        private ApointmentService _apointmentService;
        private IMapper _mapper;

        public ApointmentAPIService(ApointmentService apointmentService, IMapper mapper)
        {
            _apointmentService = apointmentService;
            _mapper = mapper;
        }
        public string AddApointment(ApointmentAPIModel apointmentAPIModel)
        {
            return _apointmentService.Add(_mapper.Map<ApointmentDTO>(apointmentAPIModel));
        }
        public string DeleteApointment(ApointmentAPIModel apointmentAPIModel)
        {
            return _apointmentService.Delete(apointmentAPIModel.Id);
        }
        public string GetAllApointmentAsJosn()
        {
            return JsonConvert.SerializeObject(_apointmentService.GetAll());
        }
        public string GetApointmentBuIdAsJson(int id)
        {
            return JsonConvert.SerializeObject(_apointmentService.GetById(id));
        }   
        public string Update(ApointmentAPIModel apointmentAPIModel)
        {
            return _apointmentService.Update(_mapper.Map<ApointmentDTO>(apointmentAPIModel));
        }
    }
}
