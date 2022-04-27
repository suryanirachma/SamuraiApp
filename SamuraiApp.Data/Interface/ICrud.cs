using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Data.Interface
{
    public interface ICrud<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> GetByName(string name);
        Task<T> Insert(T entity); //kalo pake entity itu bisa apa aja. objek atau apapun
        Task<T> Update(int id,T entity);
        Task Delete(int id);
    }
}
