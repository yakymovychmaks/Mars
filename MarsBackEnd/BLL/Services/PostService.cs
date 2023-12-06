using AutoMapper;
using BLL.Interface;
using BLL.ModelDTOs.UserDTOs;
using DLL.Model.UserModel;
using DLL.Repository;


namespace BLL.Services
{
    public class PostService : IService<PostDTO>
    {
        private PostRepository _postRepository;
        private IMapper _mapper;
        public PostService(PostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public string Add(PostDTO entity)
        {   
            try
            {
                if(entity == null)
                    return "can't be null";
                return _postRepository.Add(_mapper.Map<Post>(entity));
            }
            catch (Exception ex)
            {
                return "Exception on BLL layer " + ex.Message;
            }
        }

        public string Delete(PostDTO entity)
        {
            try
            {
                if (entity == null)
                    return "can't be null";
                return _postRepository.Delete(entity.Id);
            }
            catch (Exception ex)
            {
                return "Exception on BLL layer " + ex.Message;
            }
        }

        public IEnumerable<PostDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<PostDTO>>(_postRepository.GetAll());
        }

        public PostDTO? GetById(int id)
        {
            try
            {
                return _mapper.Map<PostDTO>(_postRepository.GetById(id));
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public string Update(PostDTO entity)
        {
            try
            {
                if(entity == null)
                    return "can't be null";
                return _postRepository.Update(_mapper.Map<Post>(entity));
            }
            catch(Exception ex)
            {
                return "Exception on BLL layer " + ex.Message;
            }
        }
    }
}
