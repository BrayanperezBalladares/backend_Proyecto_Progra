using ProyectoIProgra2.Data;
using ProyectoIProgra2.Entidades;

namespace ProyectoIProgra2.Servicios
{
    public class TurnoServicio : ITurnoServicio
    {
        private readonly MyAppDbContext _MyAppDbContext;
        public TurnoServicio(MyAppDbContext myAppDbContext)
        {
            _MyAppDbContext = myAppDbContext;
        }

        public bool EstaDentroDeTurno(int HoraInicio, int HoraFin)
        {
            return _MyAppDbContext.Turnos.Any(t =>
        t.HoraInicio <= HoraInicio &&
        t.HoraFin >= HoraFin
    );
        }
    }
}
