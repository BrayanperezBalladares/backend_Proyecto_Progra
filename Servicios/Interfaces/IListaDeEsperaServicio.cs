using ProyectoIProgra2.Entidades;

public interface IListaDeEsperaServicio
{
    public List<ListaDeEspera> ListarListaEspera();

    public ListaDeEspera BuscarPorId(int listaId);

    public List<ListaDeEspera> ObtenerListaPorTurno(int turnoId);

    public ListaDeEspera CrearListaDeEspera(ListaDeEspera lista);

    public ListaDeEspera ActualizarListaDeEspera(int listaId, ListaDeEspera lista);
    public void EliminarClienteEnListaDeEspera(int listaId);
    public Reserva ConvertirAReserva(int listaId, int mesaId);
    public ListaDeEspera ObtenerSiguienteEnEspera(int turnoId);
    public bool HayPersonasEnEspera(int turnoId);
}