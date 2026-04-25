using ProyectoIProgra2.Data;
using ProyectoIProgra2.Entidades;

namespace ProyectoIProgra2.Servicios
{
    public class ClienteServicio : IClienteServicio
    {
        private readonly MyAppDbContext _myDbContext;
        public ClienteServicio(MyAppDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        public List<Cliente> ListarClientes()
        {
            return _myDbContext.Clientes.ToList();
        }

        public Cliente BuscarClientePorId(int clienteId)
        {
            var result = _myDbContext.Clientes.Find(clienteId);
            return result;
        }
        public Cliente BuscarClientePorCedula(int cedula)
        {
            var result = _myDbContext.Clientes
                .FirstOrDefault(c => c.Ced == cedula);

            return result;
        }
        public List<Reserva> ObtenerReservasDelCliente(int clienteId)
        {
            var result = _myDbContext.Reservas
         .Where(r => r.ClienteId == clienteId)
         .ToList();

            return result;
        }
        public Cliente CrearCliente(Cliente cliente)
        {
            _myDbContext.Clientes.Add(cliente);
            _myDbContext.SaveChanges();
            return cliente;
        }
        public Cliente ActualizarCliente(int clienteId, Cliente cliente)
        {
            var result = _myDbContext.Clientes.Find(clienteId);
            result.Nombre = cliente.Nombre;
            _myDbContext.Update(result);
            _myDbContext.SaveChanges();
            return result;
        }

        public void EliminarCliente(int clienteId)
        {
            var result = _myDbContext.Clientes.Find(clienteId);
            _myDbContext.Clientes.Remove(result);
            _myDbContext.SaveChanges();
        }

        

        
    }
}
