using ProyectoIProgra2.Entidades;

public interface IEstadoDeReservaServicio
{
    public List<EstadoDeReserva> ListarEstados();
    public EstadoDeReserva BuscarEstadoPorId(int estadoId);

}