namespace SamuraiApp.API.DTO.Samurais
{
    public class CreateSamuraiWithPedangDTO
    {
        public string Name { get; set; }
        public List<CreatePedangSamuraiDTO> Pedangs { get; set; }
    }
}
//samurai with pedang ini punya relasi one to many jadi dipedang itu butuh satu parameter yaitu samurai id

