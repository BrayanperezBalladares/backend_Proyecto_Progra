using Microsoft.AspNetCore.Mvc;
using ProyectoIProgra2.Data;
using ProyectoIProgra2.Entidades;

namespace ProyectoIProgra2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoDeReservaController : ControllerBase
    {
        private readonly MyAppDbContext _db;

        public EstadoDeReservaController(MyAppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<List<EstadoDeReserva>> Listar()
        {
            return Ok(_db.EstadoDeReservas.ToList());
        }
    }
}
