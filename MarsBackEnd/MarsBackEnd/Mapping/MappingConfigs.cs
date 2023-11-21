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
            CreateMap<AdminAPIModel, AdminDTO>()
    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
    .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

            CreateMap<AdminDTO, AdminAPIModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));
            CreateMap<PostsAPIModel, PostsDTO>().ReverseMap();
            CreateMap<DoctorAPIModel,DoctorDTO>().ReverseMap();
            CreateMap<PatientAPIModel, PatientDTO>().ReverseMap();
            CreateMap<OfficeAPIModel,OfficeDTO>().ReverseMap();
            CreateMap<ApointmentAPIModel, ApointmentDTO>().ReverseMap();
        }
    }
}
