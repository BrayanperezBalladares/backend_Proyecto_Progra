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
            result.ZonaId = zona.ZonaId;
            _MyAppDbContext.Zonas.Update(result);
            _MyAppDbContext.SaveChanges();
            return result;
        }

        public Zona BuscarZonaPorId(int zonaId)
        {
            var result = _MyAppDbContext.Zonas.Find(zonaId);
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
            _MyAppDbContext.Zonas.Remove(result);
            _MyAppDbContext.SaveChanges();
        }

        public List<Zona> ListarZonas()
        {
            return _MyAppDbContext.Zonas.ToList();
        }

        public List<Mesa> ObtenerTodasLasMesasDeUnaZona(int zonaId)
        {
            throw new NotImplementedException();
        }
    }
}
