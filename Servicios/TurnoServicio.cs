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
        public Turno ActualizarTurno(int turnoId, Turno turno)
        {
            var result = _MyAppDbContext.Turnos.Find(turnoId);
            result.TurnoId = turno.TurnoId;
            _MyAppDbContext.Turnos.Update(result);
            _MyAppDbContext.SaveChanges();
            return result;
        }

        public Turno BuscarTurnoPorId(int turnoId)
        {
            var result = _MyAppDbContext.Turnos.Find(turnoId);
            return result;
        }

        public Turno CrearTurno(Turno turno)
        {
            _MyAppDbContext.Turnos.Add(turno);
            _MyAppDbContext.SaveChanges();
            return turno;
        }

        public void EliminarTurno(int turnoId)
        {
            var result = _MyAppDbContext.Turnos.Find(turnoId);
            _MyAppDbContext.Turnos.Remove(result);
            _MyAppDbContext.SaveChanges();
        }

        public bool EstaDentroDeTurno(DateTime inicio, DateTime fin)
        {
            throw new NotImplementedException();
        }

        public bool TurnoDisponible(DateTime fechaHora)
        {
            throw new NotImplementedException();
        }

        public bool ValidarHorarioReserva(DateTime inicio, DateTime fin)
        {
            throw new NotImplementedException();
        }
    }
}
