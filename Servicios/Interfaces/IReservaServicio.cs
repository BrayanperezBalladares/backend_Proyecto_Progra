using ProyectoIProgra2.Entidades;

public interface IReservaServicio
{
    public List<Reserva> ListarReservas();
    public Reserva BuscarReservaPorId(int reservaId);
    public List<Reserva> ObtenerReservasPorFecha(DateTime fecha);
    public List<Reserva> ObtenerReservaPorClienteId(int clienteId);
    public Reserva CrearReserva(Reserva reserva);
    public Reserva ActualizarReserva(int reservaId, Reserva reserva);
    public Reserva CambiarEstadoReserva(int reservaId, int estadoId);
    public Reserva AsignarMesa(int reservaId, int mesaId);
    public Reserva CancelarReserva(int reservaId);
    public void EliminarReserva(int reservaId);
    public bool EstaDentroDeTurno(DateTime inicio, DateTime fin);
    public bool ValidarReserva(Reserva reserva);
    public bool ComprobarDisponibilidadDeReservas(int mesaId, DateTime inicio, DateTime fin);
    public void ProcesarListaDeEspera(int mesaId, DateTime inicio, DateTime fin);
    public List<Reserva> BuscarReservasPorEstadoId(int estado);

    //buscar reserva x estado en reserva
}