using ProyectoIProgra2.Entidades;

public interface IMesaServicio
{
    public List<Mesa> ListarMesas();
    public Mesa BuscarMesaPorId(int mesaId);
    public Mesa BuscarMesaPorNumero(int numero);

    public List<Mesa> ObtenerMesaPorZona(int zonaId);

    public List<Mesa> ObtenerMesaPorCapacidad(int capacidad);

    public Mesa CrearMesa(Mesa mesa);
    bool ComprobarDisponibilidadMesa(int mesaId, DateTime inicio, DateTime fin);
    public List<Mesa> ObtenerMesasDisponibles(DateTime inicio, DateTime fin, int capacidad);
}