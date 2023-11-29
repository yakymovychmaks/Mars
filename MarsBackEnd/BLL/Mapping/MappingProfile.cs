using AutoMapper;
using BLL.ModelDTOs.UserDTOs;
using DLL.Model.UserModel;


namespace BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<PostDTO, Post>().ReverseMap();
            CreateMap<ApointmentDTO, Apointment>().ReverseMap();
        }
    }
}
