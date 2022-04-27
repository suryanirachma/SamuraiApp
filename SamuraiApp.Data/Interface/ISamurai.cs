using SamuraiAppDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Data.Interface
{
    public interface ISamurai :ICrud<Samurai>
    {
        Task<IEnumerable<Samurai>> GetAllSamuraiWithPedang();
    //nampilin semua samurai dengan semua pedang
        Task<Samurai> GetByIdSamuraiWithPedang(int id);
        //nampilin id si samurainya

        Task<IEnumerable<Samurai>> GetAllSamuraiWithPedangAndElemen();
        Task<Samurai> GetByIdSamuraiWithPedangAndElemen(int id);
    }
}
