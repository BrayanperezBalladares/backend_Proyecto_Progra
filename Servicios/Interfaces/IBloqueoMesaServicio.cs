using ProyectoIProgra2.Entidades;

public interface IBloqueoMesaServicio
{
    public BloqueoMesa BuscarBloqueoPorId(int bloqueoId);

    public List<BloqueoMesa> ObtenerBloqueosPorMesaId(int mesaId);

    public BloqueoMesa CrearBloqueoMesa(BloqueoMesa bloqueo);

    public BloqueoMesa ActualizarBloqueoMesa(int bloqueoId, BloqueoMesa bloqueo); 

    public void EliminarBloqueoMesa(int bloqueoId);
    public bool ExisteInterferenciaBloqueoMesa(int mesaId, DateTime inicio, DateTime fin);
    public BloqueoMesa DesbloquearMesa(int mesaId);
    public List<BloqueoMesa> ActualizarZona(int zonaId, DateTime inicio, DateTime fin, bool activa); //se va llamar "actualizar zona" y va a recibir un booleano para la nueva entidad "Activa"
}