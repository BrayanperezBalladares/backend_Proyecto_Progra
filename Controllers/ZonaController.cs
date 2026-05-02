using Microsoft.AspNetCore.Mvc;
using ProyectoIProgra2.Entidades;
using ProyectoIProgra2.Servicios;

namespace ProyectoIProgra2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZonaController : ControllerBase
    {
        private readonly IZonaServicio _zonaServicio;

        public ZonaController(IZonaServicio zonaServicio)
        {
            _zonaServicio = zonaServicio;
        }

        // GET: api/zona
        [HttpGet]
        public ActionResult<List<Zona>> ListarZonas()
        {
            var zonas = _zonaServicio.ListarZonas();
            return Ok(zonas);
        }

        // GET: api/zona/5
        [HttpGet("{id}")]
        public ActionResult<Zona> BuscarZonaPorId(int id)
        {
            try
            {
                var zona = _zonaServicio.BuscarZonaPorId(id);
                return Ok(zona);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/zona/5/mesas
        [HttpGet("{id}/mesas")]
        public ActionResult<List<Mesa>> ObtenerMesasDeUnaZona(int id)
        {
            try
            {
                var mesas = _zonaServicio.ObtenerMesasDeUnaZona(id);
                return Ok(mesas);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/zona
        [HttpPost]
        public ActionResult<Zona> CrearZona([FromBody] Zona zona)
        {
            try
            {
                var nuevaZona = _zonaServicio.CrearZona(zona);
                return CreatedAtAction(nameof(BuscarZonaPorId), new { id = nuevaZona.ZonaId }, nuevaZona);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/zona/5
        [HttpPut("{id}")]
        public ActionResult<Zona> ActualizarZona(int id, [FromBody] Zona zona)
        {
            try
            {
                var zonaActualizada = _zonaServicio.ActualizarZona(id, zona);
                return Ok(zonaActualizada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/zona/5
        [HttpDelete("{id}")]
        public ActionResult EliminarZona(int id)
        {
            try
            {
                _zonaServicio.EliminarZona(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}