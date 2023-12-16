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
            return JsonConvert.SerializeObject(_mapper.Map<IEnumerable<PostsAPIModel>>(_postService.GetAll()));
        }
        public string GetPostByIdAsJson(int id)
        {
            return JsonConvert.SerializeObject(_postService.GetById(id));
        }
        public string AddPsot(PostsAPIModel postsAPIModel)
        {
            return _postService.Add(_mapper.Map<PostDTO>(postsAPIModel)); ;
        }
        public string DeletePsot(PostsAPIModel postsAPIModel) 
        {
            return _postService.Delete(_mapper.Map<PostDTO>(postsAPIModel));
        }
        public string UpdatePost(PostsAPIModel post)
        {
            return _postService.Update(_mapper.Map<PostDTO>(post));
        }
    }
}
