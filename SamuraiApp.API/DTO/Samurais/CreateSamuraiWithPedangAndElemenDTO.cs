namespace SamuraiApp.API.DTO.Samurais
{
    public class CreateSamuraiWithPedangAndElemenDTO
    {
        public string Name { get; set; }
        public List<CreatePedangElemenSamuraiDTO> Pedangs { get; set; }
    }
}
