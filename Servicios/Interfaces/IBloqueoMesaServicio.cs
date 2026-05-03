using ProyectoIProgra2.DTOs;
using ProyectoIProgra2.Entidades;
namespace ProyectoIProgra2.Servicios
{
    public interface IBloqueoMesaServicio
    {
        public BloqueoMesaDto BuscarBloqueoPorId(int bloqueoId);

        public List<BloqueoMesaDto> ObtenerBloqueosPorMesaId(int mesaId);

        public BloqueoMesaDto CrearBloqueoMesa(BloqueoMesaDto bloqueo);

        public BloqueoMesaDto ActualizarBloqueoMesa(int bloqueoId, BloqueoMesaDto bloqueo); 

        public void EliminarBloqueoMesa(int bloqueoId);
        public bool ExisteInterferenciaBloqueoMesa(int mesaId, DateTime HoraInicio, DateTime HoraFin);
        public BloqueoMesaDto DesbloquearMesa(int mesaId);
        public List<BloqueoMesaDto> ActualizarZona(int zonaId, DateTime HoraInicio, DateTime HoraFin, bool activa); //se va llamar "actualizar zona" y va a recibir un booleano para la nueva entidad "Activa"
    }
}
