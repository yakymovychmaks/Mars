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
                {
                    return "wrong data";
                }
                var rez = _mapper.Map<Post>(entity);
                _postRepository.Add(rez);
                return "okey";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Delete(PostDTO entity)
        {
            try
            {
                if (_postRepository.GetById(entity.Id) == null)
                {
                    return "cant be null";
                }
                return _postRepository.Delete(entity.Id);

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IEnumerable<PostDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<PostDTO>>(_postRepository.GetAll());
        }

        public PostDTO? GetById(int id)
        {
            if (id != 0)
            {

                if (_postRepository.GetById(id) != null)
                    return _mapper.Map<PostDTO>(_postRepository.GetById(id));
                else return null;
            }
            else return null;
        }

        public string Update(PostDTO entity)
        {
            try
            {
                if(entity == null)
                {
                    return "can't be null";
                }
                _postRepository.Update(_mapper.Map<Post>(entity));
                return "okey";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public string CreatePost(PostDTO postDTO)
        {
            try
            {
                return "ok";
            }catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
