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
        public string GetAllAdminAsJson()
        {
            try
            {
                var result = _userService.GetAll();
                var serializedResult = JsonConvert.SerializeObject(result);
                return serializedResult;
            }catch (Exception ex)
            {
                return "Sorry " + ex.Message;
            }
        }



        public string AddUser(UserAPIModel model)
        {

            try
            {
                var adminAPIModel = model;
                _userService.Add(_mapper.Map<UserDTO>(adminAPIModel));
                return JsonConvert.SerializeObject(adminAPIModel);
            }
            catch (Exception ex) 
            { return "AdminAPIService error : " + ex.Message; }
        }
        public string GetAdminByIdJson(int id)
        {
            try
            {
                var result = _userService.GetById(id);
                var serializedResult = JsonConvert.SerializeObject(result);
                return serializedResult;
            }catch (Exception ex) { return "AdminApiService error: "+ex.Message; }
        }
        public string UpdataAdmin(int id ,UserAPIModel adminUpdate)
        {
            try
            {
                if(_userService.GetById(id) != null)
                {
                    _userService.Delete(_mapper.Map<UserDTO>(adminUpdate));   
                    //_userService.Delete(id); 
                    //_userService.Add(_mapper.Map<UserDTO>(adminUpdate));
                    return "Success : " + JsonConvert.SerializeObject(adminUpdate);
                }
                return "Admin not found";
            }
            catch (Exception ex)
            {
                return "AdminAPIService" + ex.Message;
            }
        }

        public string AddPost(PostsAPIModel addPost)
        {
            try
            {
                return _postService.CreatePost(_mapper.Map<PostDTO>(addPost));
            }catch (Exception ex)
            {
                return "Sorry: " + ex.Message;
            }
        }
    }
}
