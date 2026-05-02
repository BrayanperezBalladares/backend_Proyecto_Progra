using Microsoft.AspNetCore.Mvc;
using ProyectoIProgra2.DTOs;
using ProyectoIProgra2.Entidades;
using ProyectoIProgra2.Servicios;

namespace ProyectoIProgra2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaDeEsperaController : ControllerBase
    {
        private readonly IListaDeEsperaServicio _listaDeEsperaServicio;

        public ListaDeEsperaController(IListaDeEsperaServicio listaDeEsperaServicio)
        {
            _listaDeEsperaServicio = listaDeEsperaServicio;
        }

        // GET: api/listadeespera
        [HttpGet]
        public ActionResult<List<ListaDeEsperaDto>> ListarListaEspera()
        {
            var lista = _listaDeEsperaServicio.ListarListaEspera();
            return Ok(lista);
        }

        // GET: api/listadeespera/5
        [HttpGet("{id}")]
        public ActionResult<ListaDeEsperaDto> BuscarPorId(int id)
        {
            try
            {
                var entrada = _listaDeEsperaServicio.BuscarPorId(id);
                return Ok(entrada);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/listadeespera/turno/3
        [HttpGet("turno/{turnoId}")]
        public ActionResult<List<ListaDeEsperaDto>> ObtenerListaPorTurno(int turnoId)
        {
            var lista = _listaDeEsperaServicio.ObtenerListaPorTurno(turnoId);
            return Ok(lista);
        }

        // GET: api/listadeespera/turno/3/siguiente?capacidadMesa=4
        [HttpGet("turno/{turnoId}/siguiente")]
        public ActionResult<ListaDeEspera> ObtenerSiguienteEnEspera(int turnoId, [FromQuery] int capacidadMesa)
        {
            try
            {
                var siguiente = _listaDeEsperaServicio.ObtenerSiguienteEnEspera(turnoId, capacidadMesa);
                return Ok(siguiente);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // GET: api/listadeespera/turno/3/hayespera
        [HttpGet("turno/{turnoId}/hayespera")]
        public ActionResult<bool> HayPersonasEnEspera(int turnoId)
        {
            var hay = _listaDeEsperaServicio.HayPersonasEnEspera(turnoId);
            return Ok(hay);
        }

        // POST: api/listadeespera
        [HttpPost]
        public ActionResult<ListaDeEspera> CrearListaDeEspera([FromBody] ListaDeEspera lista)
        {
            try
            {
                var entrada = _listaDeEsperaServicio.CrearListaDeEspera(lista);
                return CreatedAtAction(nameof(BuscarPorId), new { id = entrada.ListaDeEsperaId }, entrada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/listadeespera/5/convertir?mesaId=2
        [HttpPost("{id}/convertir")]
        public ActionResult<ReservaDto> ConvertirAReserva(int id, [FromQuery] int mesaId)
        {
            try
            {
                var reserva = _listaDeEsperaServicio.ConvertirAReserva(id, mesaId);
                return Ok(reserva);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/listadeespera/5
        [HttpPut("{id}")]
        public ActionResult<ListaDeEsperaDto> ActualizarListaDeEspera(int id, [FromBody] ListaDeEsperaDto dto)
        {
            try
            {
                var entrada = _listaDeEsperaServicio.ActualizarListaDeEspera(id, dto);
                return Ok(entrada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/listadeespera/5
        [HttpDelete("{id}")]
        public ActionResult EliminarClienteEnListaDeEspera(int id)
        {
            try
            {
                _listaDeEsperaServicio.EliminarClienteEnListaDeEspera(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}