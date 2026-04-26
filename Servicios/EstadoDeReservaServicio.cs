using ProyectoIProgra2.Data;
using ProyectoIProgra2.Entidades;

namespace ProyectoIProgra2.Servicios
{
    public class EstadoDeReservaServicio : IEstadoDeReservaServicio
    {
        private readonly MyAppDbContext _MyAppDbContext;
        public EstadoDeReservaServicio(MyAppDbContext myAppDbContext)
        {
            _MyAppDbContext = myAppDbContext;
        }
        public EstadoDeReserva ActualizarEstadoDeReserva(int estadoId, EstadoDeReserva estado)
        {
            var result = _MyAppDbContext.EstadoDeReservas.Find(estadoId);
            result.EstadoDeReservaId = estado.EstadoDeReservaId;
            _MyAppDbContext.EstadoDeReservas.Update(result);
            _MyAppDbContext.SaveChanges();
            return result;
        }

        public EstadoDeReserva BuscarEstadoDeReservaPorId(int estadoId)
        {
            var result = _MyAppDbContext.EstadoDeReservas.Find(estadoId);
            return result;
        }

        public EstadoDeReserva CrearEstadoDeReserva(EstadoDeReserva estado)
        {
            _MyAppDbContext.EstadoDeReservas.Add(estado);
            _MyAppDbContext.SaveChanges();
            return estado;
        }

        public void EliminarEstadoDeReserva(int estadoId)
        {
            var result = _MyAppDbContext.EstadoDeReservas.Find(estadoId);
            _MyAppDbContext.EstadoDeReservas.Remove(result);
            _MyAppDbContext.SaveChanges();
        }

        public List<EstadoDeReserva> ListarEstados()
        {
            return _MyAppDbContext.EstadoDeReservas.ToList();
        }
    }
}
