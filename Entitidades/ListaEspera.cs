namespace ProyectoIProgra2.Entities
{
    public class ListaEspera
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int TurnoId { get; set; }
        public int CantidadPersonas { get; set; }
        public DateTime HoraSolicitud { get; set; }
        public string Estado { get; set; }
    }
}