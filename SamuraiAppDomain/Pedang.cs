using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiAppDomain
{
    public class Pedang
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public int Tahun { get; set; }
        public string Berat { get; set; }
        public Samurai Samurai { get; set; }
        public int SamuraiId { get; set; }
        public List<Elemen>Elemens { get; set; } = new List<Elemen>();
    }
}
