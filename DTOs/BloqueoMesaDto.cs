namespace ProyectoIProgra2.DTOs
{
    public class BloqueoMesaDto
    {
        public int MesaId { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public DateTime Fecha { get; set; }
        public string Detalle { get; set; }
    }
}
/*Investigue y vi que es recomendado hacer varios DTOs (No se si aplicarlo).

EntidadDTO:
El cliente envía información al API (POST/PUT). No van Id's porque eso lo debería generar la base de datos.

ResponseDTO:
 Se usa cuando la API le devuelve información al cliente(Get). Aquí si va el Id y lo que quiere que vea el cliente.


 * public class BloqueoMesaResponseDTO
{
    public int Id { get; set; }
    public int NumMesa { get; set; }
    public DateTime HoraInicio { get; set; }
    public DateTime HoraFin { get; set; }
    public DateTime Fecha { get; set; }
    public string Detalle { get; set; }
}*/