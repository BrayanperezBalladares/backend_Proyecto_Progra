using ProyectoIProgra2.Entidades;

public interface IEstadoDeReservaServicio
{
    public List<EstadoDeReserva> ListarEstados();
    public EstadoDeReserva BuscarEstadoDeReservaPorId(int estadoId);
    public EstadoDeReserva CrearEstadoDeReserva(EstadoDeReserva estado);

  

    public void EliminarEstadoDeReserva(int estadoId);
}