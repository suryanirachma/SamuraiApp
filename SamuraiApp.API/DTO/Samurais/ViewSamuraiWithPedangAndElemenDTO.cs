using SamuraiApp.API.DTO.Pedangs;

namespace SamuraiApp.API.DTO.Samurais
{
    public class ViewSamuraiWithPedangAndElemenDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ViewPedangWithElemenDTO> Pedangs { get; set; }
    }
}
