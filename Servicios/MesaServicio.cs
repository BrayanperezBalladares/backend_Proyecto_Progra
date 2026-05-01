using ProyectoIProgra2.Data;
using ProyectoIProgra2.Entidades;

namespace ProyectoIProgra2.Servicios
{
    public class MesaServicio : IMesaServicio
    {
        private readonly MyAppDbContext _MyAppDbContext;
        public MesaServicio(MyAppDbContext myAppDbContext)
        {
            _MyAppDbContext = myAppDbContext;
        }

        public Mesa BuscarMesaPorId(int mesaId)
        {
            var result = _MyAppDbContext.Mesas.Find(mesaId);

            if (result == null)
                throw new Exception("Mesa no encontrada");

            return result;

        }

        public Mesa ComprobarDisponibilidadMesa(int mesaId, DateTime inicio, DateTime fin)
        {
            var mesa = _MyAppDbContext.Mesas.Find(mesaId);
            if (mesa == null)
                throw new Exception("La mesa no existe");

            bool sinReservas = !_MyAppDbContext.Reservas.Any(r =>
            r.MesaId == mesaId &&
            r.EstadoDeReservaId != 2 &&
            inicio < r.HoraFin &&
            fin > r.HoraInicio
            );

            bool sinBloqueos = !_MyAppDbContext.BloqueosMesas.Any(b =>
            b.MesaId == mesaId &&
            inicio < b.HoraFin &&
            fin > b.HoraInicio
            );

            if (!sinReservas)
                throw new Exception("La mesa ya tiene una reserva en ese horario");

            if (!sinBloqueos)
                throw new Exception("La mesa está bloqueada en ese horario");

            return mesa;

        }

        public Mesa CrearMesa(Mesa mesa)
        {
            var zona = _MyAppDbContext.Zonas.Find(mesa.ZonaId);
            if (zona == null)
                throw new Exception("La zona asignada no existe");

            if (mesa.Capacidad <= 0)
                throw new Exception("La capacidad debe ser mayor a 0");

            _MyAppDbContext.Mesas.Add(mesa);
            _MyAppDbContext.SaveChanges();

            return mesa;

        }

        public List<Mesa> ListarMesas()
        {
            return _MyAppDbContext.Mesas.ToList();
        }

        public List<Mesa> ObtenerMesasDisponibles(DateTime inicio, DateTime fin, int capacidad)
        {
        return _MyAppDbContext.Mesas
        .Where(m =>
        m.Capacidad >= capacidad &&

        !_MyAppDbContext.Reservas.Any(r =>
         r.MesaId == m.MesaId &&
         r.EstadoDeReservaId != 2 &&
         inicio < r.HoraFin &&
         fin > r.HoraInicio) &&

        !_MyAppDbContext.BloqueosMesas.Any(b =>
         b.MesaId == m.MesaId &&
         inicio < b.HoraFin &&
         fin > b.HoraInicio)
         )
         .ToList();

        }

        public List<Mesa> ObtenerMesasPorCapacidad(int capacidad)
        {
        return _MyAppDbContext.Mesas
        .Where(m => m.Capacidad >= capacidad)
        .ToList();
        }

        public List<Mesa> ObtenerMesasPorZona(int zonaId)
        {
        var zona = _MyAppDbContext.Zonas.Find(zonaId);

        if (zona == null)
        throw new Exception("Zona no encontrada");

        return _MyAppDbContext.Mesas
        .Where(m => m.ZonaId == zonaId)
        .ToList();
        }
    }
}
