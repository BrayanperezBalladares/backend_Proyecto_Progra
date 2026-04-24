using ProyectoIProgra2.Entidades;

namespace ProyectoIProgra2.Servicios
{
    public class ReservaServicio : IReservaServicio
    {
        public Reserva ActualizarReserva(int reservaId, Reserva reserva)
        {
            throw new NotImplementedException();
        }

        public Reserva AsignarMesa(int reservaId, int mesaId)
        {
            throw new NotImplementedException();
        }

        public Reserva BuscarReservaPorId(int reservaId)
        {
            throw new NotImplementedException();
        }

        public Reserva CambiarEstadoReserva(int reservaId, int estadoId)
        {
            throw new NotImplementedException();
        }

        public bool ComprobarDisponibilidadDeReservas(int mesaId, DateTime inicio, DateTime fin)
        {
            throw new NotImplementedException();
        }

        public Reserva CrearReserva(Reserva reserva)
        {
            throw new NotImplementedException();
        }

        public void EliminarReserva(int reservaId)
        {
            throw new NotImplementedException();
        }

        public List<Reserva> ListarReservas()
        {
            throw new NotImplementedException();
        }

        public List<Reserva> ObtenerReservaPorClienteId(int clienteId)
        {
            throw new NotImplementedException();
        }

        public List<Reserva> ObtenerReservasPorFecha(DateTime fecha)
        {
            throw new NotImplementedException();
        }
    }
}
