using AutoMapper;
using BLL.Interface;
using BLL.ModelDTOs.UserDTOs;
using DLL.Model.UserModel;
using DLL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CommentService : IService<CommentDTO>
    {
        private CommentRepository _commentRepository;
        private IMapper _mapper;
        public CommentService (CommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }
        public string Add(CommentDTO entity)
        {
            try
            {
                if (entity == null)
                    return "can't be null";
                return _commentRepository.Add(_mapper.Map<Comment>(entity));
            }
            catch (Exception ex)
            {
                return "Exeption on the BLL layer" + ex.Message;
            }
        }

        public string Delete(int id)
        {
            try
            {
                if (id == null)
                    return "can't be null";
                return _commentRepository.Delete(id);
            }
            catch (Exception ex)
            {
                return "Exeption on the BLL layer" + ex.Message;
            }
        }

        public IEnumerable<CommentDTO> GetAll()
        {
            try
            {
                return _mapper.Map<IEnumerable<CommentDTO>>(_commentRepository.GetAll());
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public CommentDTO GetById(int id)
        {
            try
            {
                return _mapper.Map<CommentDTO>(_commentRepository.GetById(id));
            }
            catch
            {
                return null;
            }
        }

        public string Update(CommentDTO entity)
        {
            try
            {
                if (entity == null)
                    return "can't be null";
                return _commentRepository.Update(_mapper.Map<Comment>(entity));
            }
            catch (Exception ex)
            {
                return "Exeption on the BLL layer" + ex.Message;
            }
        }
    }
}
