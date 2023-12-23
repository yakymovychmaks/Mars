using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Interface
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        Task Create(T entity);
        Task Delete(T entity);
        Task<T> Update(T entity);
    }
}
