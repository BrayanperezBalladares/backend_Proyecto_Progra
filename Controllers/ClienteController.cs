using Microsoft.AspNetCore.Mvc;
using ProyectoIProgra2.DTOs;
using ProyectoIProgra2.Servicios;

namespace ProyectoIProgra2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteServicio _clienteServicio;

        public ClienteController(IClienteServicio clienteServicio)
        {
            _clienteServicio = clienteServicio;
        }

        // GET: api/cliente
        [HttpGet]
        public ActionResult<List<ClienteDto>> ListarClientes()
        {
            var clientes = _clienteServicio.ListarClientes();
            return Ok(clientes);
        }

        // GET: api/cliente/5
        [HttpGet("{id}")]
        public ActionResult<ClienteDto> BuscarClientePorId(int id)
        {
            try
            {
                var cliente = _clienteServicio.BuscarClientePorId(id);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/cliente/cedula/123456789
        [HttpGet("cedula/{cedula}")]
        public ActionResult<ClienteDto> BuscarClientePorCedula(int cedula)
        {
            try
            {
                var cliente = _clienteServicio.BuscarClientePorCedula(cedula);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/cliente/5/reservas
        [HttpGet("{id}/reservas")]
        public ActionResult ObtenerReservasDelCliente(int id)
        {
            try
            {
                var reservas = _clienteServicio.ObtenerReservasDelCliente(id);
                return Ok(reservas);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/cliente
        [HttpPost]
        public ActionResult<ClienteDto> CrearCliente([FromBody] ClienteDto dto)
        {
            try
            {
                var cliente = _clienteServicio.CrearCliente(dto);
                return CreatedAtAction(nameof(BuscarClientePorId), new { id = cliente.ClienteId }, cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/cliente/5
        [HttpPut("{id}")]
        public ActionResult<ClienteDto> ActualizarCliente(int id, [FromBody] ClienteDto dto)
        {
            try
            {
                var cliente = _clienteServicio.ActualizarCliente(id, dto);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/cliente/5
        [HttpDelete("{id}")]
        public ActionResult EliminarCliente(int id)
        {
            try
            {
                _clienteServicio.EliminarCliente(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}