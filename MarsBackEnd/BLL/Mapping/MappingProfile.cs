using AutoMapper;
using BLL.ModelDTOs.AdminDTOs;
using BLL.ModelDTOs.UserDTOs;
using DLL.Models.AdminsModel;
using DLL.Models.UserModel;


namespace BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AdminDTO, Admin>().ReverseMap();
            CreateMap<PostDTO, Posts>().ReverseMap();
            CreateMap<DoctorDTO, Doctor>().ReverseMap();
            CreateMap<PatientDTO, Patient>().ReverseMap();
            CreateMap<ApointmentDTO, Apointment>().ReverseMap();
            CreateMap<OfficeDTO, Office>().ReverseMap();
        }
    }
}
