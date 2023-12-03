using AutoMapper;
using BLL.ModelDTOs.UserDTOs;
using BLL.Services;
using MarsBackEnd.Models.UserAPIModeles;
using Newtonsoft.Json;


namespace MarsBackEnd.APIServices
{
    public class PostAPIService
    {
        private PostService _postService;
        private IMapper _mapper;
        public PostAPIService(PostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }
        public string GetAllPostsByJson()
        {
            try
            {
                var models = _postService.GetAll();
                var serializedObject = JsonConvert.SerializeObject(models);
                return serializedObject;
            }
            catch (Exception ex)
            {
                return "Sorry: "+ex.Message;
            }
        }
        public string GetPostByIdAsJson(int id)
        {
            if (_postService.GetById(id) == null)
                return "Nothing to found";
            return JsonConvert.SerializeObject(_postService.GetById(id));
        }
        public string AddPsot(PostsAPIModel postsAPIModel)
        {
            if (postsAPIModel == null)
                return "can't be null";
            
            return _postService.Add(_mapper.Map<PostDTO>(postsAPIModel)); ;
        }
        public string DeletePsot(int id) 
        {
            var postsAPIModel = _postService.GetById(id);
            if (postsAPIModel == null) return " can't be null";
            _postService.Delete(_mapper.Map<PostDTO>(postsAPIModel));
            return "post was delete";
        }
    }
}
