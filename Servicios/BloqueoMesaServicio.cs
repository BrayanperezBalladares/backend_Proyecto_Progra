using ProyectoIProgra2.Data;
using ProyectoIProgra2.DTOs;
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

        public BloqueoMesaDto ActualizarBloqueoMesa(int bloqueoId, BloqueoMesaDto dto)
        {
            var result = _MyAppDbContext.BloqueosMesas.Find(bloqueoId);
            if (result == null)
                throw new Exception("Bloqueo no encontrado");

            if (dto.HoraInicio >= dto.HoraFin)
                throw new Exception("HoraFin  debe ser despues a la de HoraInicio");

            result.MesaId = dto.MesaId;
            result.HoraInicio = dto.HoraInicio;
            result.HoraFin = dto.HoraFin;
            result.Fecha = dto.Fecha;
            result.Detalle = dto.Detalle;

            _MyAppDbContext.Update(result);
            _MyAppDbContext.SaveChanges();
            dto.BloqueoMesaId = result.BloqueoMesaId;
            return dto;

        }

        public List<BloqueoMesaDto> ActualizarZona(int zonaId, DateTime inicio, DateTime fin, bool activa)
        {
            var zona = _MyAppDbContext.Zonas.Find(zonaId);
            if (zona == null)
                throw new Exception("Zona no encontrada");

            var mesas = _MyAppDbContext.Mesas
                .Where(m => m.ZonaId == zonaId)
                .ToList();

            if (!mesas.Any())
                throw new Exception("No se encontraron mesas  en esa zona");

            var resultado = new List<BloqueoMesaDto>();

            if (activa)
            {
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

                    resultado.Add(new BloqueoMesaDto
                    {
                        BloqueoMesaId = bloqueo.BloqueoMesaId,
                        MesaId = bloqueo.MesaId,
                        Fecha = bloqueo.Fecha,
                        HoraInicio = bloqueo.HoraInicio,
                        HoraFin = bloqueo.HoraFin,
                        Detalle = bloqueo.Detalle
                    });
                });
                _MyAppDbContext.SaveChanges();
            }
            else
            {
                var mesaIds = mesas.Select(m => m.MesaId).ToList();

                var bloqueos = _MyAppDbContext.BloqueosMesas
                    .Where(b =>
                        b.HoraInicio == inicio &&
                        b.HoraFin == fin &&
                        mesaIds.Contains(b.MesaId))
                    .ToList();

                _MyAppDbContext.BloqueosMesas.RemoveRange(bloqueos);
                _MyAppDbContext.SaveChanges();

                resultado = bloqueos.Select(b => new BloqueoMesaDto
                {
                    BloqueoMesaId = b.BloqueoMesaId,
                    MesaId = b.MesaId,
                    Fecha = b.Fecha,
                    HoraInicio = b.HoraInicio,
                    HoraFin = b.HoraFin,
                    Detalle = b.Detalle
                }).ToList();
            }

            return resultado;
        }

        public BloqueoMesaDto BuscarBloqueoPorId(int bloqueoId)
        {
            var result = _MyAppDbContext.BloqueosMesas.Find(bloqueoId);

            if (result == null)
                throw new Exception("Bloqueo no encontrado");

            return new BloqueoMesaDto
            {
                BloqueoMesaId = result.BloqueoMesaId,
                MesaId = result.MesaId,
                Fecha = result.Fecha,
                HoraInicio = result.HoraInicio,
                HoraFin = result.HoraFin,
                Detalle = result.Detalle
            }
            ;
        }

        public BloqueoMesaDto CrearBloqueoMesa(BloqueoMesaDto dto)
        {
            var mesa = _MyAppDbContext.Mesas.Find(dto.MesaId);
            if (mesa == null)
                throw new Exception("La mesa no existe");

            if (dto.HoraInicio >= dto.HoraFin)
                throw new Exception("HoraFin debe ser posterior a HoraInicio");

            var reservasAfectadas = _MyAppDbContext.Reservas
                .Where(r =>
                    r.MesaId == dto.MesaId &&
                    r.EstadoDeReservaId == 1 &&
                    r.HoraInicio < dto.HoraFin &&
                    r.HoraFin > dto.HoraInicio)
                .ToList();

            reservasAfectadas.ForEach(r =>
            {
                r.EstadoDeReservaId = 2;
                _MyAppDbContext.Update(r);
            });

            var bloqueo = new BloqueoMesa
            {
                MesaId = dto.MesaId,
                Fecha = dto.Fecha,
                HoraInicio = dto.HoraInicio,
                HoraFin = dto.HoraFin,
                Detalle = dto.Detalle
            };

            _MyAppDbContext.BloqueosMesas.Add(bloqueo);
            _MyAppDbContext.SaveChanges();
            dto.BloqueoMesaId = bloqueo.BloqueoMesaId;
            return dto;

        }

        public BloqueoMesaDto DesbloquearMesa(int mesaId)
        {
            var bloqueos = _MyAppDbContext.BloqueosMesas
                .Where(b => b.MesaId == mesaId)
                .ToList();
            if (!bloqueos.Any())
                throw new Exception("No hay bloqueos activos para esa mesa");

            _MyAppDbContext.BloqueosMesas.RemoveRange(bloqueos);
            _MyAppDbContext.SaveChanges();

            var b = bloqueos.First();// Solo devolvemos el primer bloqueo eliminado
                                        // con la información de la mesa desbloqueada

            return new BloqueoMesaDto
            {
                BloqueoMesaId = b.BloqueoMesaId,
                MesaId = b.MesaId,
                Fecha = b.Fecha,
                HoraInicio = b.HoraInicio,
                HoraFin = b.HoraFin,
                Detalle = b.Detalle

            };
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

        public List<BloqueoMesaDto> ObtenerTodos()
        {
            return _MyAppDbContext.BloqueosMesas
                .Select(b => new BloqueoMesaDto
                {
                    BloqueoMesaId = b.BloqueoMesaId,
                    MesaId = b.MesaId,
                    Fecha = b.Fecha,
                    HoraInicio = b.HoraInicio,
                    HoraFin = b.HoraFin,
                    Detalle = b.Detalle
                })
                .ToList();
        }

        public List<BloqueoMesaDto> ObtenerBloqueosPorMesaId(int mesaId)
        {
            return _MyAppDbContext.BloqueosMesas
                .Where(b => b.MesaId == mesaId)
                .Select(b => new BloqueoMesaDto
                {
                    BloqueoMesaId = b.BloqueoMesaId,
                    MesaId = b.MesaId,
                    Fecha = b.Fecha,
                    HoraInicio = b.HoraInicio,
                    HoraFin = b.HoraFin,
                    Detalle = b.Detalle
                })
                .ToList();
        }
    }
}
