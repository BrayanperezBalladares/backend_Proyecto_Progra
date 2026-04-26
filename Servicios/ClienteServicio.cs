using ProyectoIProgra2.Data;
using ProyectoIProgra2.Entidades;

namespace ProyectoIProgra2.Servicios
{
    public class ClienteServicio : IClienteServicio
    {
        private readonly MyAppDbContext _MyAppDbContext;
        public ClienteServicio(MyAppDbContext myAppDbContext)
        {   
            _MyAppDbContext = myAppDbContext;
        }
        public Cliente ActualizarCliente(int clienteId, Cliente cliente)
        {
            var result = _MyAppDbContext.Clientes.Find(clienteId);
            result.ClienteId = cliente.ClienteId;
            _MyAppDbContext.Clientes.Update(result);
            _MyAppDbContext.SaveChanges();
            return result;
        }

        public Cliente BuscarClientePorCedula(int cedula)
        {
            throw new NotImplementedException();
        }

        public Cliente BuscarClientePorId(int clienteId)
        {
            var result = _MyAppDbContext.Clientes.Find(clienteId);
            return result;
        }

        public Cliente CrearCliente(Cliente cliente)
        {
            _MyAppDbContext.Clientes.Add(cliente);
            _MyAppDbContext.SaveChanges();
            return cliente;
        }

        public void EliminarCliente(int clienteId)
        {
            var result = _MyAppDbContext.Clientes.Find(clienteId);
            _MyAppDbContext.Clientes.Remove(result);
            _MyAppDbContext.SaveChanges();
        }

        public bool ExisteClientePorCedula(int cedula)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> ListarClientes()
        {
            return _MyAppDbContext.Clientes.ToList();
        }

        public List<Reserva> ObtenerReservasDelCliente(int clienteId)
        {
            throw new NotImplementedException();
        }
    }
}
