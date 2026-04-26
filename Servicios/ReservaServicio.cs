using ProyectoIProgra2.Data;
using ProyectoIProgra2.Entidades;

namespace ProyectoIProgra2.Servicios
{
    public class ReservaServicio : IReservaServicio
    {
        private readonly MyAppDbContext _MyAppDbContext;
        public ReservaServicio(MyAppDbContext myAppDbContext)
        {
            _MyAppDbContext = myAppDbContext;
        }
        public Reserva ActualizarReserva(int reservaId, Reserva reserva)
        {
            var result = _MyAppDbContext.Reservas.Find(reservaId);
            result.ReservaId = reserva.ReservaId;
            _MyAppDbContext.Reservas.Update(result);
            _MyAppDbContext.SaveChanges();
            return result;
        }

        public Reserva AsignarMesa(int reservaId, int mesaId)
        {
            throw new NotImplementedException();
        }

        public Reserva BuscarReservaPorId(int reservaId)
        {
            var result = _MyAppDbContext.Reservas.Find(reservaId);
            return result;
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
            _MyAppDbContext.Reservas.Add(reserva);
            _MyAppDbContext.SaveChanges();
            return reserva;
        }

        public void EliminarReserva(int reservaId)
        {
            var result = _MyAppDbContext.Reservas.Find(reservaId);
            _MyAppDbContext.Reservas.Remove(result);
            _MyAppDbContext.SaveChanges();
        }

        public bool ExisteInterferenciaDeHorario(int mesaId, DateTime inicio, DateTime fin)
        {
            throw new NotImplementedException();
        }

        public void LiberarMesa(int ReservaId)
        {
            throw new NotImplementedException();
        }

        public List<Reserva> ListarReservas()
        {
            return _MyAppDbContext.Reservas.ToList();
        }

        public List<Reserva> ObtenerReservaPorClienteId(int clienteId)
        {
            throw new NotImplementedException();
        }

        public List<Reserva> ObtenerReservasPorFecha(DateTime fecha)
        {
            throw new NotImplementedException();
        }

        public bool ValidarReserva(Reserva reserva)
        {
            throw new NotImplementedException();
        }
    }
}
