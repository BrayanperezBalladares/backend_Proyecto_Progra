using ProyectoIProgra2.DTOs;
using ProyectoIProgra2.Entidades;

namespace ProyectoIProgra2.Servicios
{
    public interface IClienteServicio
    {
        public List<ClienteDto> ListarClientes();

        public ClienteDto BuscarClientePorId(int clienteId);

        public ClienteDto BuscarClientePorCedula(int cedula);

        public List<Reserva> ObtenerReservasDelCliente(int clienteId);

        public ClienteDto CrearCliente(ClienteDto cliente);

        public ClienteDto ActualizarCliente(int clienteId, ClienteDto cliente);

        public void EliminarCliente(int clienteId);
    }
}