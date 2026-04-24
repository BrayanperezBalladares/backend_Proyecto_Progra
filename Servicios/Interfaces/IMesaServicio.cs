using ProyectoIProgra2.Entidades;

public interface IMesaServicio
{
    public List<Mesa> ListarMesas();

    public Mesa BuscarMesaPorNumero(int numero);

    public List<Mesa> ObtenerMesaPorZona(int zonaId);

    public List<Mesa> ObtenerMesaPorCapacidad(int capacidad);

    public bool ComprobarDisponibilidadMesa(int mesaId, DateTime inicio, DateTime fin);

    public Mesa CrearMesa(Mesa mesa);

    public Mesa ActualizarMesa(int mesaId, Mesa mesa);

    public Mesa AsignarReservaAMesa(int mesaId, int reservaId);

    public void EliminarMesa(int mesaId);
}