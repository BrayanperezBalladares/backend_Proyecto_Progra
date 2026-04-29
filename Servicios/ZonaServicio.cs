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

            result.ZonaId = zona.ZonaId;
            _MyAppDbContext.Zonas.Update(result);
            _MyAppDbContext.SaveChanges();
            return result;

        }

        public Zona BuscarZonaPorId(int zonaId)
        {
            throw new NotImplementedException();
        }

        public Zona CrearZona(Zona zona)
        {
            throw new NotImplementedException();
        }

        public void EliminarZona(int zonaId)
        {
            throw new NotImplementedException();
        }

        public List<Zona> ListarZonas()
        {
            throw new NotImplementedException();
        }

        public List<Mesa> ObtenerMesasDeUnaZona(int zonaId)
        {
            throw new NotImplementedException();
        }
    }
}
