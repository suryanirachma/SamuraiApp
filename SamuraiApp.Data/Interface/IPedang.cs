using SamuraiAppDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Data.Interface
{
    public interface IPedang:ICrud<Pedang>
    {
        Task<IEnumerable<Pedang>> GetAllPedangWithElemen();
        Task<Pedang> GetByIdPedangWithElemen(int id);
    }
}
