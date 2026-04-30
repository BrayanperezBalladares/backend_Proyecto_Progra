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

        public Turno BuscarTurnoPorId(int turnoId)
        {
            var result = _MyAppDbContext.Turnos.Find(turnoId);

            if (result == null)
                throw new Exception("Turno no encontrado");

            return result;
        }

        public Turno CrearTurno(Turno turno)
        {
            if (turno.HorarioInicio >= turno.HorarioFin)
                throw new Exception("HorarioFin debe ser despues del HorarioInicio");

            bool existeInterferencia = _MyAppDbContext.Turnos.Any(t =>
                turno.HorarioInicio < t.HorarioFin &&
                turno.HorarioFin > t.HorarioInicio
            );

            if (existeInterferencia)
                throw new Exception("Ya existe un turno en ese rango de horario");


            _MyAppDbContext.Turnos.Add(turno);
            _MyAppDbContext.SaveChanges();
            return turno;

        }

        public bool EstaDentroDeTurno(DateTime inicio, DateTime fin)
        {
            return _MyAppDbContext.Turnos.Any(t =>
             inicio.TimeOfDay >= t.HorarioInicio.TimeOfDay &&
             fin.TimeOfDay <= t.HorarioFin.TimeOfDay
         );
        }

        public Turno ObtenerTurnoPorHorario(DateTime Hora)
        {
            TimeSpan hora = Hora.TimeOfDay;

            var result = _MyAppDbContext.Turnos
                .FirstOrDefault(t =>
                t.HorarioInicio.TimeOfDay <= hora &&
                t.HorarioFin.TimeOfDay >= hora
                );
            if (result == null)
                throw new Exception("No existe un turno para ese horario");

            return result;
        }

        public bool TurnoDisponible(DateTime fechaHora)
        {
            TimeSpan hora = fechaHora.TimeOfDay;

            return _MyAppDbContext.Turnos.Any(t =>
                t.HorarioInicio.TimeOfDay <= hora &&
                t.HorarioFin.TimeOfDay >= hora
            );
        }
    }
}
