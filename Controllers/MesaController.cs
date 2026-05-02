using Microsoft.AspNetCore.Mvc;
using ProyectoIProgra2.Entidades;
using ProyectoIProgra2.Servicios;

namespace ProyectoIProgra2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesaController : ControllerBase
    {
        private readonly IMesaServicio _mesaServicio;

        public MesaController(IMesaServicio mesaServicio)
        {
            _mesaServicio = mesaServicio;
        }

        // GET: api/mesa
        [HttpGet]
        public ActionResult<List<Mesa>> ListarMesas()
        {
            var mesas = _mesaServicio.ListarMesas();
            return Ok(mesas);
        }

        // GET: api/mesa/5
        [HttpGet("{id}")]
        public ActionResult<Mesa> BuscarMesaPorId(int id)
        {
            try
            {
                var mesa = _mesaServicio.BuscarMesaPorId(id);
                return Ok(mesa);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/mesa/zona/3
        [HttpGet("zona/{zonaId}")]
        public ActionResult<List<Mesa>> ObtenerMesasPorZona(int zonaId)
        {
            try
            {
                var mesas = _mesaServicio.ObtenerMesasPorZona(zonaId);
                return Ok(mesas);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/mesa/capacidad/4
        [HttpGet("capacidad/{capacidad}")]
        public ActionResult<List<Mesa>> ObtenerMesasPorCapacidad(int capacidad)
        {
            var mesas = _mesaServicio.ObtenerMesasPorCapacidad(capacidad);
            return Ok(mesas);
        }

        // GET: api/mesa/disponibles?inicio=2025-01-01T12:00&fin=2025-01-01T14:00&capacidad=4
        [HttpGet("disponibles")]
        public ActionResult<List<Mesa>> ObtenerMesasDisponibles(
            [FromQuery] DateTime inicio,
            [FromQuery] DateTime fin,
            [FromQuery] int capacidad)
        {
            try
            {
                var mesas = _mesaServicio.ObtenerMesasDisponibles(inicio, fin, capacidad);
                return Ok(mesas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/mesa/5/disponibilidad?inicio=2025-01-01T12:00&fin=2025-01-01T14:00
        [HttpGet("{id}/disponibilidad")]
        public ActionResult<Mesa> ComprobarDisponibilidadMesa(
            int id,
            [FromQuery] DateTime inicio,
            [FromQuery] DateTime fin)
        {
            try
            {
                var mesa = _mesaServicio.ComprobarDisponibilidadMesa(id, inicio, fin);
                return Ok(mesa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/mesa
        [HttpPost]
        public ActionResult<Mesa> CrearMesa([FromBody] Mesa mesa)
        {
            try
            {
                var nuevaMesa = _mesaServicio.CrearMesa(mesa);
                return CreatedAtAction(nameof(BuscarMesaPorId), new { id = nuevaMesa.MesaId }, nuevaMesa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}