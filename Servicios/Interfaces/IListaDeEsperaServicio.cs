using ProyectoIProgra2.Entidades;

public interface IListaDeEsperaServicio
{
    public List<ListaDeEspera> ListarListaEspera();

    public ListaDeEspera BuscarPorId(int listaId);

    public List<ListaDeEspera> ObtenerListaPorTurno(int turnoId);

    public ListaDeEspera CrearListaDeEspera(ListaDeEspera lista);

    public ListaDeEspera ActualizarListaDeEspera(int listaId, ListaDeEspera lista);

    public ListaDeEspera AsignarMesaDesdeLista(int listaId, int mesaId);

    public ListaDeEspera CambiarEstadoLista(int listaId, int estadoId);

    public void EliminarListaDeEspera(int listaId);
}