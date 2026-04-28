using ProyectoIProgra2.Data;
using ProyectoIProgra2.Entidades;

namespace ProyectoIProgra2.Servicios
{
    public class BloqueoMesaServicio : IBloqueoMesaServicio
    {
        public BloqueoMesa ActualizarBloqueoMesa(int bloqueoId, BloqueoMesa bloqueo)
        {
            throw new NotImplementedException();
        }

        public BloqueoMesa BuscarBloqueoPorId(int bloqueoId)
        {
            throw new NotImplementedException();
        }

        public BloqueoMesa CrearBloqueoMesa(BloqueoMesa bloqueo)
        {
            throw new NotImplementedException();
        }

        public BloqueoMesa DesbloquearMesa(int mesaId)
        {
            throw new NotImplementedException();
        }

        public void EliminarBloqueoMesa(int bloqueoId)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
       