using ProyectoIProgra2.Entidades;

public interface IBloqueoMesaServicio
{
    public BloqueoMesa BuscarBloqueoPorId(int bloqueoId);

    public List<BloqueoMesa> ObtenerBloqueoPorMesaId(int mesaId);

    public BloqueoMesa CrearBloqueoMesa(BloqueoMesa bloqueo);

    public BloqueoMesa ActualizarBloqueoMesa(int bloqueoId, BloqueoMesa bloqueo);

    public void EliminarBloqueoMesa(int bloqueoId);

    public bool EstaMesaBloqueada(int mesaId, DateTime inicio, DateTime fin);
    public bool ExisteInterferenciaBloqueoMesa(int mesaId, DateTime inicio, DateTime fin);
}