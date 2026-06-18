using Microsoft.AspNetCore.Mvc;
using ProyectoIProgra2.DTOs;
using ProyectoIProgra2.Servicios;

namespace ProyectoIProgra2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloqueoMesaController : ControllerBase
    {
        private readonly IBloqueoMesaServicio _bloqueoMesaServicio;

        public BloqueoMesaController(IBloqueoMesaServicio bloqueoMesaServicio)
        {
            _bloqueoMesaServicio = bloqueoMesaServicio;
        }

        // GET: api/bloqueomesa
        [HttpGet]
        public ActionResult<List<BloqueoMesaDto>> ObtenerTodos()
        {
            return Ok(_bloqueoMesaServicio.ObtenerTodos());
        }

        // GET: api/bloqueomesa/mesa/5
        [HttpGet("mesa/{mesaId}")]
        public ActionResult<List<BloqueoMesaDto>> ObtenerBloqueosPorMesaId(int mesaId)
        {
            var bloqueos = _bloqueoMesaServicio.ObtenerBloqueosPorMesaId(mesaId);
            return Ok(bloqueos);
        }

        // GET: api/bloqueomesa/5
        [HttpGet("{id}")]
        public ActionResult<BloqueoMesaDto> BuscarBloqueoPorId(int id)
        {
            try
            {
                var bloqueo = _bloqueoMesaServicio.BuscarBloqueoPorId(id);
                return Ok(bloqueo);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/bloqueomesa/interferencia?mesaId=1&inicio=2025-01-01T12:00&fin=2025-01-01T14:00
        [HttpGet("interferencia")]
        public ActionResult<bool> ExisteInterferencia([FromQuery] int mesaId,
                                                        [FromQuery] DateTime inicio,
                                                        [FromQuery] DateTime fin)
        {
            var existe = _bloqueoMesaServicio.ExisteInterferenciaBloqueoMesa(mesaId, inicio, fin);
            return Ok(existe);
        }

        // POST: api/bloqueomesa
        [HttpPost]
        public ActionResult<BloqueoMesaDto> CrearBloqueoMesa([FromBody] BloqueoMesaDto dto)
        {
            try
            {
                var bloqueo = _bloqueoMesaServicio.CrearBloqueoMesa(dto);
                return CreatedAtAction(nameof(BuscarBloqueoPorId), new { id = bloqueo.BloqueoMesaId }, bloqueo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/bloqueomesa/zona
        [HttpPost("zona")]
        public ActionResult<List<BloqueoMesaDto>> BloquearZona([FromQuery] int zonaId,
                                                                [FromQuery] DateTime inicio,
                                                                [FromQuery] DateTime fin)
        {
            try
            {
                var bloqueos = _bloqueoMesaServicio.ActualizarZona(zonaId, inicio, fin, true);
                return Ok(bloqueos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/bloqueomesa/zona
        [HttpDelete("zona")]
        public ActionResult<List<BloqueoMesaDto>> DesbloquearZona([FromQuery] int zonaId,
                                                                    [FromQuery] DateTime inicio,
                                                                    [FromQuery] DateTime fin)
        {
            try
            {
                var bloqueos = _bloqueoMesaServicio.ActualizarZona(zonaId, inicio, fin, false);
                return Ok(bloqueos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/bloqueomesa/5
        [HttpPut("{id}")]
        public ActionResult<BloqueoMesaDto> ActualizarBloqueoMesa(int id, [FromBody] BloqueoMesaDto dto)
        {
            try
            {
                var bloqueo = _bloqueoMesaServicio.ActualizarBloqueoMesa(id, dto);
                return Ok(bloqueo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/bloqueomesa/5
        [HttpDelete("{id}")]
        public ActionResult EliminarBloqueoMesa(int id)
        {
            try
            {
                _bloqueoMesaServicio.EliminarBloqueoMesa(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/bloqueomesa/mesa/5/desbloquear
        [HttpDelete("mesa/{mesaId}/desbloquear")]
        public ActionResult<BloqueoMesaDto> DesbloquearMesa(int mesaId)
        {
            try
            {
                var bloqueo = _bloqueoMesaServicio.DesbloquearMesa(mesaId);
                return Ok(bloqueo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}