namespace ProyectoIProgra2.Entidades
{
    public class ListaDeEspera
    {
        public int ListaDeEsperaId { get; set; }
        public int ClienteId { get; set; }
        public int TurnoId { get; set; }
        public int CantidadPersonas { get; set; }
        public DateTime HoraSolicitud { get; set; }
        
    }
}