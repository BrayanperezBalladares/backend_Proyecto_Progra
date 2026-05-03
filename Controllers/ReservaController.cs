using Microsoft.AspNetCore.Mvc;
using ProyectoIProgra2.DTOs;
using ProyectoIProgra2.Servicios;

namespace ProyectoIProgra2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaServicio _reservaServicio;

        public ReservaController(IReservaServicio reservaServicio)
        {
            _reservaServicio = reservaServicio;
        }

        // GET: api/reserva
        [HttpGet]
        public ActionResult<List<ReservaDto>> ListarReservas()
        {
            var reservas = _reservaServicio.ListarReservas();
            return Ok(reservas);
        }

        // GET: api/reserva/5
        [HttpGet("{id}")]
        public ActionResult<ReservaDto> BuscarReservaPorId(int id)
        {
            try
            {
                var reserva = _reservaServicio.BuscarReservaPorId(id);
                return Ok(reserva);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/reserva/cliente/3
        [HttpGet("cliente/{clienteId}")]
        public ActionResult<List<ReservaDto>> ObtenerReservaPorClienteId(int clienteId)
        {
            var reservas = _reservaServicio.ObtenerReservaPorClienteId(clienteId);
            return Ok(reservas);
        }

        // GET: api/reserva/fecha?fecha=2025-01-01
        [HttpGet("fecha")]

        // GET: api/reserva/estado/1
        [HttpGet("estado/{estadoId}")]
        public ActionResult<List<ReservaDto>> BuscarReservasPorEstadoId(int estadoId)
        {
            var reservas = _reservaServicio.BuscarReservasPorEstadoId(estadoId);
            return Ok(reservas);
        }

        // GET: api/reserva/disponibilidad?mesaId=1&inicio=2025-01-01T12:00&fin=2025-01-01T14:00
        [HttpGet("disponibilidad")]
        public ActionResult<bool> ComprobarDisponibilidad(
            [FromQuery] int mesaId,
            [FromQuery] DateTime inicio,
            [FromQuery] DateTime fin)
        {
            var disponible = _reservaServicio.ComprobarDisponibilidadDeReservas(mesaId, inicio, fin);
            return Ok(disponible);
        }

        // GET: api/reserva/dentroturno?inicio=2025-01-01T12:00&fin=2025-01-01T14:00
        [HttpGet("dentroturno")]
        public ActionResult<bool> EstaDentroDeTurno(
            [FromQuery] DateTime inicio,
            [FromQuery] DateTime fin)
        {
            var dentroTurno = _reservaServicio.EstaDentroDeTurno(inicio, fin);
            return Ok(dentroTurno);
        }

        // POST: api/reserva
        [HttpPost]
        public ActionResult<ReservaDto> CrearReserva([FromBody] ReservaDto dto)
        {
            try
            {
                var reserva = _reservaServicio.CrearReserva(dto);
                return CreatedAtAction(nameof(BuscarReservaPorId), new { id = reserva.ReservaId }, reserva);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/reserva/5
        [HttpPut("{id}")]
        public ActionResult<ReservaDto> ActualizarReserva(int id, [FromBody] ReservaDto dto)
        {
            try
            {
                var reserva = _reservaServicio.ActualizarReserva(id, dto);
                return Ok(reserva);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/reserva/5/mesa/3
        [HttpPut("{id}/mesa/{mesaId}")]
        public ActionResult<ReservaDto> AsignarMesa(int id, int mesaId)
        {
            try
            {
                var reserva = _reservaServicio.AsignarMesa(id, mesaId);
                return Ok(reserva);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/reserva/5/estado/2
        [HttpPut("{id}/estado/{estadoId}")]
        public ActionResult<ReservaDto> CambiarEstadoReserva(int id, int estadoId)
        {
            try
            {
                var reserva = _reservaServicio.CambiarEstadoReserva(id, estadoId);
                return Ok(reserva);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/reserva/5/cancelar
        [HttpPut("{id}/cancelar")]
        public ActionResult<ReservaDto> CancelarReserva(int id)
        {
            try
            {
                var reserva = _reservaServicio.CancelarReserva(id);
                return Ok(reserva);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/reserva/5
        [HttpDelete("{id}")]
        public ActionResult EliminarReserva(int id)
        {
            try
            {
                _reservaServicio.EliminarReserva(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}