using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiAppDomain
{
    public class Elemen
    {
        public int ElemenId { get; set; }
        public string Name { get; set; }
        public List<Pedang> Pedangs { get; set; } = new List<Pedang>();

    }
}
