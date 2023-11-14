using AutoMapper;
using BLL.Interface;
using BLL.ModelDTOs.AdminDTOs;
using DLL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PostService : IService<PostsDTO>
    {
        private PostRepository _postRepository;
        private IMapper _mapper;
        public void SetRepositorys(PostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public IEnumerable<PostsDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<PostsDTO>>(_postRepository.GetAll());
        }

        public PostsDTO? GetById(int id)
        {
            if (id != 0)
            {

                if (_postRepository.GetById(id) != null)
                    return _mapper.Map<PostsDTO>(_postRepository.GetById(id));
                else return null;
            }
            else return null;
        }
    }
}
