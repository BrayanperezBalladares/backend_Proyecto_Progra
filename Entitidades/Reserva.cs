namespace ProyectoIProgra2.Entities
{
    public class Reserva
    {
        public int Id { get; set; }
        public int TurnoId { get; set; }
        public int EstadoDeReservaId { get; set; }
        public int CantidaPersonas { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public int MesaId { get; set; }
    }
}