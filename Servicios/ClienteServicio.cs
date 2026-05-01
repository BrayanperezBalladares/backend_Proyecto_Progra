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
            if (result == null)
                throw new Exception("No se encuentra al cliente");

            if (result.Ced != cliente.Ced && ExisteClientePorCedula(cliente.Ced))
                throw new Exception("Ya existe otro cliente con esa cédula");

            result.Ced = cliente.Ced;
            result.Nombre = cliente.Nombre;
            result.Apellidos = cliente.Apellidos;
            result.Tel = cliente.Tel;
            result.Email = cliente.Email;
            _MyAppDbContext.Update(result);
            _MyAppDbContext.SaveChanges();
            return result;

        }

        public Cliente BuscarClientePorCedula(int cedula)
        {
            var result = _MyAppDbContext.Clientes
              .FirstOrDefault(c => c.Ced == cedula);
            if (result == null)
                throw new Exception("No se encuentra al cliente");
            return result;
        }

        public Cliente BuscarClientePorId(int clienteId)
        {
            var result = _MyAppDbContext.Clientes.Find(clienteId);
            if (result == null)
                throw new Exception("No se encuentra al cliente");
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
            if (result == null)
                throw new Exception("No se encuentra al cliente");

            bool tieneReservasActivas = _MyAppDbContext.Reservas
                .Any(r => r.ClienteId == clienteId &&
                          r.EstadoDeReservaId == 1);

            if (tieneReservasActivas)
                throw new Exception("No se puede eliminar un cliente con reservas activas");
            _MyAppDbContext.Clientes.Remove(result);
            _MyAppDbContext.SaveChanges();

        }

        public List<Cliente> ListarClientes()
        {
            return _MyAppDbContext.Clientes.ToList();

        }

        public List<Reserva> ObtenerReservasDelCliente(int clienteId)
        {
            return _MyAppDbContext.Reservas
                .Where(r => r.ClienteId == clienteId)
                .ToList();

        }
        private bool ExisteClientePorCedula(int cedula)
        {
            return _MyAppDbContext.Clientes
                .Any(c => c.Ced == cedula);
        }

    }
}
