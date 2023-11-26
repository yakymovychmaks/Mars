using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        string Add(T entity);
        string Update(T entity);
        string Delete(T entity);
    }
}
