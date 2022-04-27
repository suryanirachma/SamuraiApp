using SamuraiApp.API.DTO.Elemens;

namespace SamuraiApp.API.DTO.Pedangs
{
    public class ViewPedangWithElemenDTO
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public int Tahun { get; set; }
        public string Berat { get; set; }
        public List<ElemenDTO> Elemens { get; set; }

    }
}
