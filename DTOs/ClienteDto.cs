namespace ProyectoIProgra2.DTOs
{
    public class ClienteDto
    {
        public int ClienteId { get; set; }
        public int Ced { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Tel { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
