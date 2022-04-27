using SamuraiApp.API.DTO.Elemens;

namespace SamuraiApp.API.DTO.Samurais
{
    public class CreatePedangElemenSamuraiDTO
    {
        public string Nama { get; set; }
        public int Tahun { get; set; }
        public string Berat { get; set; }
        public List<ElemenCreateDTO> Elemens { get; set; }
    }
}
