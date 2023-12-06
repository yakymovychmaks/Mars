using AutoMapper;
using BLL.ModelDTOs.UserDTOs;
using BLL.Services;
using MarsBackEnd.Models.UserAPIModeles;
using Newtonsoft.Json;

namespace MarsBackEnd.APIServices
{
    public class CommentAPIService
    {
        private CommentService _commentService;
        private IMapper _mapper;
        public CommentAPIService(CommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }
        public string AddComment(CommentAPImodel commentAPImodel)
        {
            return _commentService.Add(_mapper.Map<CommentDTO>(commentAPImodel));
        }
        public string DeleteComment(CommentAPImodel commentAPImodel)
        {
            return _commentService.Delete(_mapper.Map<CommentDTO>(commentAPImodel));
        }
        public string GetAllCommentAsJson()
        {
            return JsonConvert.SerializeObject(_mapper.Map<IEnumerable<CommentAPImodel>>(_commentService.GetAll()));
        }
        public string GetCommentByIdAsJson(int id)
        {
            return JsonConvert.SerializeObject(_mapper.Map<CommentAPImodel>(_commentService.GetById(id)));
        }
        public string Update(CommentAPImodel commentAPImodel)
        {
            return _commentService.Update(_mapper.Map<CommentDTO>(commentAPImodel));
        }
    }
}
