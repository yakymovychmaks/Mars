using BLL.Interface;
using BLL.ModelDTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CommentService : IService<CommentDTO>
    {
        
        public string Add(CommentDTO entity)
        {
            
        }

        public string Delete(CommentDTO entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CommentDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public CommentDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public string Update(CommentDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
