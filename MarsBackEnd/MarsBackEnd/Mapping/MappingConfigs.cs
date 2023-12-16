using BLL.ModelDTOs.UserDTOs;
using AutoMapper;
using MarsBackEnd.Models.UserAPIModeles;

namespace MarsBackEnd.Mapping
{
    public class MappingConfigs : Profile
    {
        public MappingConfigs()
        {
            CreateMap<UserAPIModel,UserDTO>().ReverseMap();
            CreateMap<PostsAPIModel, PostDTO>().ReverseMap();
            CreateMap<ApointmentAPIModel, ApointmentDTO>().ReverseMap();
        }
    }
}
