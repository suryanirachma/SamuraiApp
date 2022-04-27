using SamuraiApp.API.DTO.Pedangs;

namespace SamuraiApp.API.DTO.Samurais
{
    public class ViewSamuraiWithPedangDTO
    {
//isinya data samurai
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PedangDTO> Pedangs { get; set; }
    }
}
