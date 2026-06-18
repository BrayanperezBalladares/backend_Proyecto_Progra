using Microsoft.AspNetCore.Mvc;
using ProyectoIProgra2.Data;
using ProyectoIProgra2.Entidades;
using ProyectoIProgra2.Servicios;

namespace ProyectoIProgra2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnoController : ControllerBase
    {
        private readonly ITurnoServicio _turnoServicio;
        private readonly MyAppDbContext _db;

        public TurnoController(ITurnoServicio turnoServicio, MyAppDbContext db)
        {
            _turnoServicio = turnoServicio;
            _db = db;
        }

        [HttpGet]
        public ActionResult<List<Turno>> Listar()
        {
            return Ok(_db.Turnos.OrderBy(t => t.HoraInicio).ToList());
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