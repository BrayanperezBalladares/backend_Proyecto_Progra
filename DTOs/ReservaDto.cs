namespace ProyectoIProgra2.DTOs
{
    public class ReservaDto
    {
        public int ClienteId { get; set; }
        public int TurnoId { get; set; }
        public int CantidaPersonas { get; set; }
        public DateTime Fecha { get; set; }
        
    }
}


/*
  
 public class ActualizarReservaDTO
{
    public int EstadoDeReservaId { get; set; }
}*/

/*
 public class ReservaResponseDTO
{
    public int ReservaId { get; set; }
        public int TurnoId { get; set; }
        public int EstadoDeReservaId { get; set; }
        public int CantidaPersonas { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public int MesaId { get; set; }
}
 */