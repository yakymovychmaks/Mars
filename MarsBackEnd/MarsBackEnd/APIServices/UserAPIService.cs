using AutoMapper;
using BLL.ModelDTOs.UserDTOs;
using BLL.Services;
using MarsBackEnd.Models.UserAPIModeles;
using Newtonsoft.Json;


namespace MarsBackEnd.APIServices
{
    public class UserAPIService
    {
        private UserService _userService;
        public PostService _postService;

        private IMapper _mapper;
        public UserAPIService(PostService postService,UserService userService, IMapper mapper)
        {
            _postService = postService;
            _userService = userService;
            _mapper = mapper;
        }
        public string GetAllUsersAsJson()
        {
            return JsonConvert.SerializeObject(_mapper.Map<IEnumerable<UserAPIModel>>(_userService.GetAll()));
        }
        public string AddUser(UserAPIModel model)
        {
            return _userService.Add(_mapper.Map<UserDTO>(model));
        }
        public string GetUserByIdJson(int id)
        {
            return JsonConvert.SerializeObject(_mapper.Map<UserAPIModel>(_postService.GetById(id)));
        }
        public string UpdataUser(int id ,UserAPIModel userUpdate)
        {
            return _userService.Update(_mapper.Map<UserDTO>(userUpdate));
        }

        public string AddPost(PostsAPIModel addPost)
        {
            return _postService.Add(_mapper.Map<PostDTO>(addPost));
        }
    }
}
