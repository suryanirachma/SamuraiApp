using SamuraiApp.API.DTO.Elemens;

namespace SamuraiApp.API.DTO.Pedangs
{
    public class CreatePedangWithElemenDTO
    {
        public string Nama { get; set; }
        public int Tahun { get; set; }
        public string Berat { get; set; }
        public int SamuraiId { get; set; }
        public List<ElemenCreateDTO> Elemens { get; set; }
    }
}
