namespace ProyectoIProgra2.DTOs
{
    public class ReservaDto
    {
        public int ReservaId { get; set; }
        public int MesaId { get; set; }
        public int ClienteId { get; set; }
        public int TurnoId { get; set; }
        public int CantidadPersonas { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public int EstadoDeReservaId { get; set; }
    }
}
