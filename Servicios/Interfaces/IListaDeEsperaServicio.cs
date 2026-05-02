using ProyectoIProgra2.Entidades;
using ProyectoIProgra2.DTOs;
using ProyectoIProgra2.Servicios;

public interface IListaDeEsperaServicio
{
    public List<ListaDeEsperaDto> ListarListaEspera();

    public ListaDeEsperaDto BuscarPorId(int listaId);

    public List<ListaDeEsperaDto> ObtenerListaPorTurno(int turnoId);

    public ListaDeEspera CrearListaDeEspera(ListaDeEspera lista);

    public ListaDeEsperaDto ActualizarListaDeEspera(int listaId, ListaDeEsperaDto lista);
    public void EliminarClienteEnListaDeEspera(int listaId);
    public ReservaDto ConvertirAReserva(int listaId, int mesaId);
    public ListaDeEspera ObtenerSiguienteEnEspera(int turnoId, int capacidadMesa);
    public bool HayPersonasEnEspera(int turnoId);
}