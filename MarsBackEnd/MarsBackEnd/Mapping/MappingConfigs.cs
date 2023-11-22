using BLL.ModelDTOs.AdminDTOs;
using MarsBackEnd.Models.Admin;
using AutoMapper;
using MarsBackEnd.Models.Users;
using BLL.ModelDTOs.UserDTOs;

namespace MarsBackEnd.Mapping
{
    public class MappingConfigs : Profile
    {
        public MappingConfigs()
        {
            CreateMap<AdminAPIModel, AdminDTO>().ReverseMap();   
            CreateMap<PostsAPIModel, PostsDTO>().ReverseMap();
            CreateMap<DoctorAPIModel,DoctorDTO>().ReverseMap();
            CreateMap<PatientAPIModel, PatientDTO>().ReverseMap();
            CreateMap<OfficeAPIModel,OfficeDTO>().ReverseMap();
            CreateMap<ApointmentAPIModel, ApointmentDTO>().ReverseMap();
        }
    }
}
