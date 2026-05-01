using ProyectoIProgra2.Entidades;

public interface IMesaServicio
{
    public List<Mesa> ListarMesas();
    public Mesa BuscarMesaPorId(int mesaId);
    

    public List<Mesa> ObtenerMesasPorZona(int zonaId);

    public List<Mesa> ObtenerMesasPorCapacidad(int capacidad);

    public Mesa CrearMesa(Mesa mesa);
    public Mesa ComprobarDisponibilidadMesa(int mesaId, DateTime inicio, DateTime fin);
    public List<Mesa> ObtenerMesasDisponibles(DateTime inicio, DateTime fin, int capacidad);
}