using ProyectoIProgra2.Data;
using ProyectoIProgra2.DTOs;
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

        public ClienteDto ActualizarCliente(int clienteId, ClienteDto dto)
        {
            var result = _MyAppDbContext.Clientes.Find(clienteId);

            if (result == null)

                throw new Exception("No se encuentra al cliente");

            if (result.Ced != dto.Ced && ExisteClientePorCedula(dto.Ced))
                throw new Exception("Ya existe otro cliente con esa cédula");

            result.Ced = dto.Ced;
            result.Nombre = dto.Nombre;
            result.Apellidos = dto.Apellidos;

            _MyAppDbContext.Update(result);
            _MyAppDbContext.SaveChanges();

            return new ClienteDto
            {
                ClienteId = result.ClienteId,
                Ced = result.Ced,
                Nombre = result.Nombre,
                Apellidos = result.Apellidos,
                Tel = result.Tel,
                Email = result.Email
            };
        }

        public ClienteDto BuscarClientePorCedula(int cedula)
        {
            var result = _MyAppDbContext.Clientes
                .FirstOrDefault(c => c.Ced == cedula);

            if (result == null)
                throw new Exception("No se encuentra al cliente");

            return new ClienteDto
            {
                ClienteId = result.ClienteId,
                Ced = result.Ced,
                Nombre = result.Nombre,
                Apellidos = result.Apellidos,
                Tel = result.Tel,
                Email = result.Email
            };
        }

        public ClienteDto BuscarClientePorId(int clienteId)
        {
            var result = _MyAppDbContext.Clientes.Find(clienteId);
            if (result == null)
                throw new Exception("No se encuentra al cliente");

            return new ClienteDto
            {
                ClienteId = result.ClienteId,
                Ced = result.Ced,
                Nombre = result.Nombre,
                Apellidos = result.Apellidos,
                Tel = result.Tel,
                Email = result.Email
            };
        }

        public ClienteDto CrearCliente(ClienteDto dto)
        {
            var cliente = new Cliente
            {
                Ced = dto.Ced,
        Nombre = dto.Nombre,
        Apellidos = dto.Apellidos,
        Tel = dto.Tel,
        Email = dto.Email ?? ""
    };

        _MyAppDbContext.Clientes.Add(cliente);
            _MyAppDbContext.SaveChanges();

            return new ClienteDto
            {
                ClienteId = cliente.ClienteId,
                Ced = cliente.Ced,
                Nombre = cliente.Nombre,
                Apellidos = cliente.Apellidos,
                Tel = cliente.Tel,
                Email = cliente.Email
            };
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

        public List<ClienteDto> ListarClientes()
        {
            return _MyAppDbContext.Clientes
                .Select(c => new ClienteDto
                {
                    ClienteId = c.ClienteId,
                    Ced = c.Ced,
                    Nombre = c.Nombre,
                    Apellidos = c.Apellidos,
                    Tel = c.Tel,
                    Email = c.Email
                })
                .ToList();
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