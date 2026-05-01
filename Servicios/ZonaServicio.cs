using ProyectoIProgra2.Data;
using ProyectoIProgra2.Entidades;

namespace ProyectoIProgra2.Servicios
{
    public class ZonaServicio : IZonaServicio
    {

        private readonly MyAppDbContext _MyAppDbContext;
        public ZonaServicio(MyAppDbContext myAppDbContext)
        {
            _MyAppDbContext = myAppDbContext;
        }
        public Zona ActualizarZona(int zonaId, Zona zona)
        {
            var result = _MyAppDbContext.Zonas.Find(zonaId);

            if (result == null)
                throw new Exception("Zona no encontrada");

            result.Seccion = zona.Seccion;

            _MyAppDbContext.Zonas.Update(result);
            _MyAppDbContext.SaveChanges();

            return result;

        }

        public Zona BuscarZonaPorId(int zonaId)
        {
            var result = _MyAppDbContext.Zonas.Find(zonaId);

            if (result == null)
                throw new Exception("Zona no encontrada");

            return result;

        }

        public Zona CrearZona(Zona zona)
        {
            _MyAppDbContext.Zonas.Add(zona);
            _MyAppDbContext.SaveChanges();
            return zona;
        }

        public void EliminarZona(int zonaId)
        {
            var result = _MyAppDbContext.Zonas.Find(zonaId);

            if (result == null)
                throw new Exception("Zona no encontrada");

            bool tieneMesasConReservas = _MyAppDbContext.Mesas
                .Where(m => m.ZonaId == zonaId)
                .Any(m => _MyAppDbContext.Reservas
                .Any(r => r.MesaId == m.MesaId &&
                r.EstadoDeReservaId == 1));

            if (tieneMesasConReservas)
                throw new Exception("No se puede eliminar una zona con mesas que tienen reservas activas");

            _MyAppDbContext.Zonas.Remove(result);
            _MyAppDbContext.SaveChanges();
        }

        public List<Zona> ListarZonas()
        {
            return _MyAppDbContext.Zonas.ToList();
        }

        public List<Mesa> ObtenerMesasDeUnaZona(int zonaId)
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
