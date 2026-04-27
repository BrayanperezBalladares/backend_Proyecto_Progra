using ProyectoIProgra2.Data;
using ProyectoIProgra2.Entidades;

namespace ProyectoIProgra2.Servicios
{
    public class ListaDeEsperaServicio : IListaDeEsperaServicio
    {
        public ListaDeEspera ActualizarListaDeEspera(int listaId, ListaDeEspera lista)
        {
            throw new NotImplementedException();
        }

        public ListaDeEspera AsignarMesaDesdeLista(int listaId, int mesaId)
        {
            throw new NotImplementedException();
        }

        public ListaDeEspera BuscarPorId(int listaId)
        {
            throw new NotImplementedException();
        }

        public Reserva ConvertirAReserva(int listaId, int mesaid)
        {
            throw new NotImplementedException();
        }

        public ListaDeEspera CrearListaDeEspera(ListaDeEspera lista)
        {
            throw new NotImplementedException();
        }

        public void EliminarClienteEnListaDeEspera(int listaId)
        {
            throw new NotImplementedException();
        }

        public List<ListaDeEspera> ListarListaEspera()
        {
            throw new NotImplementedException();
        }

        public List<ListaDeEspera> ObtenerListaPorTurno(int turnoId)
        {
            throw new NotImplementedException();
        }

        public ListaDeEspera ObtenerSiguienteEnListaDeEspera(int turnoId)
        {
            throw new NotImplementedException();
        }
    }
}
