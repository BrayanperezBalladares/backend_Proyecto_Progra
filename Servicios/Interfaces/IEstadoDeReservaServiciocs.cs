using ProyectoIProgra2.Entidades;

public interface IEstadoDeReservaServicio
{
    public List<EstadoDeReserva> ListarEstados();

    public EstadoDeReserva CrearEstadoDeReserva(EstadoDeReserva estado);

    public EstadoDeReserva ActualizarEstadoDeReserva(int estadoId, EstadoDeReserva estado);

    public void EliminarEstadoDeReserva(int estadoId);
}