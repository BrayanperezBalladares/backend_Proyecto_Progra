using Microsoft.AspNetCore.Mvc;
using ProyectoIProgra2.Servicios;

namespace ProyectoIProgra2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnoController : ControllerBase
    {
        private readonly ITurnoServicio _turnoServicio;

        public TurnoController(ITurnoServicio turnoServicio)
        {
            _turnoServicio = turnoServicio;
        }

        // GET: api/turno/dentroturno?horaInicio=12&horaFin=14
        [HttpGet("dentroturno")]
        public ActionResult<bool> EstaDentroDeTurno(
            [FromQuery] int horaInicio,
            [FromQuery] int horaFin)
        {
            var resultado = _turnoServicio.EstaDentroDeTurno(horaInicio, horaFin);
            return Ok(resultado);
        }
    }
}