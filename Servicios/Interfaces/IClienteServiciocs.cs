using ProyectoIProgra2.Entidades;

public interface IClienteServicio
{
    public List<Cliente> ListarClientes();

    public Cliente BuscarClientePorId(int clienteId);

    public Cliente BuscarClientePorCedula(string cedula);

    public List<Reserva> ObtenerReservasDelCliente(int clienteId);

    public Cliente CrearCliente(Cliente cliente);

    public Cliente ActualizarCliente(int clienteId, Cliente cliente);

    public void EliminarCliente(int clienteId);
}