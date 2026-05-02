namespace ProyectoIProgra2.DTOs
{
    public class BloqueoMesaDto
    {
        public int BloqueoMesaId { get; set; }
        public int MesaId { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public DateTime Fecha { get; set; }
        public string Detalle { get; set; }
    }
}
