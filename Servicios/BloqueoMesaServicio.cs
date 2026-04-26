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
            result.BloqueoMesaId = bloqueo.BloqueoMesaId;
            _MyAppDbContext.BloqueosMesas.Update(result);
            _MyAppDbContext.SaveChanges();
            return result;
        }

        public BloqueoMesa BuscarBloqueoPorId(int bloqueoId)
        {
            var result = _MyAppDbContext.BloqueosMesas.Find(bloqueoId);
            return result;
        }

        public BloqueoMesa CrearBloqueoMesa(BloqueoMesa bloqueo)
        {
            _MyAppDbContext.BloqueosMesas.Add(bloqueo);
            _MyAppDbContext.SaveChanges();
            return bloqueo;
        }

        public void EliminarBloqueoMesa(int bloqueoId)
        {
            var result = _MyAppDbContext.BloqueosMesas.Find(bloqueoId);
            _MyAppDbContext.BloqueosMesas.Remove(result);
            _MyAppDbContext.SaveChanges();
        }

        public bool EstaMesaBloqueada(int mesaId, DateTime inicio, DateTime fin)
        {
            throw new NotImplementedException();
        }

        public bool ExisteInterferenciaBloqueoMesa(int mesaId, DateTime inicio, DateTime fin)
        {
            throw new NotImplementedException();
        }

        public List<BloqueoMesa> ObtenerBloqueoPorMesaId()
        {
            return _MyAppDbContext.BloqueosMesas.ToList();
        }
    }
}
       