using ProyectoIProgra2.Entidades;

public interface ITurnoServicio
{
    public Turno BuscarTurnoPorId(int turnoId);

    public bool TurnoDisponible(DateTime fechaHora);

    public Turno CrearTurno(Turno turno);

    public bool EstaDentroDeTurno(DateTime inicio, DateTime fin);
    public Turno ObtenerTurnoPorHorario(DateTime fechaHora);
}