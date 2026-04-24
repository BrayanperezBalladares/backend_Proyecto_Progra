using ProyectoIProgra2.Entidades;

public interface IReservaServicio
{
    public List<Reserva> ListarReservas();

    public Reserva BuscarReservaPorId(int reservaId);

    public bool ComprobarDisponibilidadDeReservas(int mesaId, DateTime inicio, DateTime fin);

    public List<Reserva> ObtenerReservasPorFecha(DateTime fecha);

    public List<Reserva> ObtenerReservaPorClienteId(int clienteId);

    public Reserva CrearReserva(Reserva reserva);

    public Reserva ActualizarReserva(int reservaId, Reserva reserva);

    public Reserva CambiarEstadoReserva(int reservaId, int estadoId);

    public Reserva AsignarMesa(int reservaId, int mesaId);

    public void EliminarReserva(int reservaId);
}