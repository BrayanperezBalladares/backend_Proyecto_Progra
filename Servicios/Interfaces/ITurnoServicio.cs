using ProyectoIProgra2.Entidades;

public interface ITurnoServicio
{
    public Turno BuscarTurnoPorId(int turnoId);

    public bool TurnoDisponible(DateTime fechaHora);

   

    public Turno CrearTurno(Turno turno);

    public Turno ActualizarTurno(int turnoId, Turno turno);

    public void EliminarTurno(int turnoId);
    public bool EstaDentroDeTurno(DateTime inicio, DateTime fin);
}