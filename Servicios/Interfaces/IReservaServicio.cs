using ProyectoIProgra2.DTOs;

public interface IReservaServicio
{
    public List<ReservaDto> ListarReservas();
    public ReservaDto BuscarReservaPorId(int reservaId);
    public List<ReservaDto> ObtenerReservaPorClienteId(int clienteId);
    public ReservaDto CrearReserva(ReservaDto reserva);
    public ReservaDto ActualizarReserva(int reservaId, ReservaDto dto);
    public ReservaDto CambiarEstadoReserva(int reservaId, int estadoId);
    public ReservaDto AsignarMesa(int reservaId, int mesaId);
    public ReservaDto CancelarReserva(int reservaId);
    public void EliminarReserva(int reservaId);
    public bool EstaDentroDeTurno(DateTime inicio, DateTime fin);
    public bool ValidarReserva(ReservaDto reserva);
    public bool ComprobarDisponibilidadDeReservas(int mesaId, DateTime inicio, DateTime fin);
    public void ProcesarListaDeEspera(int mesaId, DateTime inicio, DateTime fin);
    public List<ReservaDto> BuscarReservasPorEstadoId(int estado);

}