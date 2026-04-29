using ProyectoIProgra2.Data;
using ProyectoIProgra2.Entidades;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectoIProgra2.Servicios
{
    public class EstadoDeReservaServicio : IEstadoDeReservaServicio
    {
        private readonly MyAppDbContext _MyAppDbContext;
        public EstadoDeReservaServicio(MyAppDbContext myAppDbContext)
        {
            _MyAppDbContext = myAppDbContext;
        }
        public EstadoDeReserva BuscarEstadoDeReservaPorNombreEstado(string estado)
        {
            var result = _MyAppDbContext.EstadoDeReservas
                .FirstOrDefault(e => e.Estado == estado);

            if (result == null)
                throw new Exception($"No existe un estado con el nombre '{estado}'");

            return result;
        }

        public EstadoDeReserva BuscarEstadoPorId(int estadoId)
        {
            var result = _MyAppDbContext.EstadoDeReservas.Find(estadoId);

            if (result == null)
                throw new Exception("Estado de reserva no encontrado");

            return result;
        }

        public List<EstadoDeReserva> ListarEstados()
        {
            return _MyAppDbContext.EstadoDeReservas.ToList();
        }
    }
}
