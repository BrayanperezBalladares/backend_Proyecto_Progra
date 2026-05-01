using ProyectoIProgra2.Data;
using ProyectoIProgra2.Entidades;

namespace ProyectoIProgra2.Servicios
{
    public class BloqueoMesaServicio : IBloqueoMesaServicio
    {
        private readonly MyAppDbContext _MyAppDbContext;
        public BloqueoMesaServicio(MyAppDbContext myAppDbContext)
        {
            _MyAppDbContext = myAppDbContext;
        }

        public BloqueoMesa ActualizarBloqueoMesa(int bloqueoId, BloqueoMesa bloqueo)
        {
            var result = _MyAppDbContext.BloqueosMesas.Find(bloqueoId);
            if (result == null)
                throw new Exception("Bloqueo no encontrado");

            if (bloqueo.HoraInicio >= bloqueo.HoraFin)
                throw new Exception("HoraFin debe ser despues a la de HoraInicio");

            result.MesaId = bloqueo.MesaId;
            result.HoraInicio = bloqueo.HoraInicio;
            result.HoraFin = bloqueo.HoraFin;
            result.Fecha = bloqueo.Fecha;
            result.Detalle = bloqueo.Detalle;

            _MyAppDbContext.Update(result);
            _MyAppDbContext.SaveChanges();
            return result;

        }

        public List<BloqueoMesa> ActualizarZona(int zonaId, DateTime inicio, DateTime fin, bool activa)
        {
            var zona = _MyAppDbContext.Zonas.Find(zonaId);
            if (zona == null)
                throw new Exception("Zona no encontrada");
            var mesas = _MyAppDbContext.Mesas
                .Where(m => m.ZonaId == zonaId).ToList();

            if (!mesas.Any())
                throw new Exception("No se encontraron mesas en esa zona");
            if (activa)
            {
            var bloqueos = new List<BloqueoMesa>();
                mesas.ForEach(mesa =>
                {
                var reservasAfectadas = _MyAppDbContext.Reservas
                   .Where(r =>
                    r.MesaId == mesa.MesaId &&
                    r.EstadoDeReservaId == 1 &&
                    r.HoraInicio < fin &&
                    r.HoraFin > inicio)
                    .ToList();

                    reservasAfectadas.ForEach(r =>
                    {
                        r.EstadoDeReservaId = 2; 
                        _MyAppDbContext.Update(r);
                    });
                    var bloqueo = new BloqueoMesa
                    {
                        MesaId = mesa.MesaId,
                        Fecha = inicio.Date,
                        HoraInicio = inicio,
                        HoraFin = fin,
                        Detalle = "Zona bloqueada"
                    };

                    _MyAppDbContext.BloqueosMesas.Add(bloqueo);
                    bloqueos.Add(bloqueo);
                });

                _MyAppDbContext.SaveChanges();
                return bloqueos;
            }
            else
            {
                var bloqueos = _MyAppDbContext.BloqueosMesas
                    .Where(b =>
                        b.HoraInicio == inicio &&
                        b.HoraFin == fin &&
                        mesas.Any(m => m.MesaId == b.MesaId))
                    .ToList();

                _MyAppDbContext.BloqueosMesas.RemoveRange(bloqueos);
                _MyAppDbContext.SaveChanges();

                return bloqueos;
            }
        }

        public BloqueoMesa BuscarBloqueoPorId(int bloqueoId)
        {
            var result = _MyAppDbContext.BloqueosMesas.Find(bloqueoId);

            if (result == null)
                throw new Exception("Bloqueo no encontrado");
            return result;

        }

        public BloqueoMesa CrearBloqueoMesa(BloqueoMesa bloqueo)
        {
            var mesa = _MyAppDbContext.Mesas.Find(bloqueo.MesaId);
            if (mesa == null)
                throw new Exception("La mesa no existe");

            if (bloqueo.HoraInicio >= bloqueo.HoraFin)
                throw new Exception("HoraFin debe ser posterior a HoraInicio");

            var reservasAfectadas = _MyAppDbContext.Reservas
               .Where(r =>
                   r.MesaId == bloqueo.MesaId &&
                   r.EstadoDeReservaId == 1 && 
                   r.HoraInicio < bloqueo.HoraFin &&
                   r.HoraFin > bloqueo.HoraInicio)
               .ToList();

            reservasAfectadas.ForEach(r =>
            {
                r.EstadoDeReservaId = 2;
                _MyAppDbContext.Update(r);
            });


            _MyAppDbContext.BloqueosMesas.Add(bloqueo);
            _MyAppDbContext.SaveChanges();
            return bloqueo;

        }

        public BloqueoMesa DesbloquearMesa(int mesaId)
        {
            var bloqueos = _MyAppDbContext.BloqueosMesas
                .Where(b => b.MesaId == mesaId)
                .ToList();
            if (!bloqueos.Any())
            throw new Exception("No hay bloqueos activos para esa mesa");

            _MyAppDbContext.BloqueosMesas.RemoveRange(bloqueos);
            _MyAppDbContext.SaveChanges();
            return bloqueos.First();

        }

        public void EliminarBloqueoMesa(int bloqueoId)
        {
            var result = _MyAppDbContext.BloqueosMesas.Find(bloqueoId);
            if (result == null)
                throw new Exception("Bloqueo no encontrado");
            _MyAppDbContext.BloqueosMesas.Remove(result);
            _MyAppDbContext.SaveChanges();

        }

        public bool ExisteInterferenciaBloqueoMesa(int mesaId, DateTime inicio, DateTime fin)
        {
            return _MyAppDbContext.BloqueosMesas
                    .Any(b => b.MesaId == mesaId &&
                        b.HoraInicio < fin &&
                        b.HoraFin > inicio);

        }

        public List<BloqueoMesa> ObtenerBloqueosPorMesaId(int mesaId)
        {
            return _MyAppDbContext.BloqueosMesas
                .Where(b => b.MesaId == mesaId)
                .ToList();
        }
    }
}
       