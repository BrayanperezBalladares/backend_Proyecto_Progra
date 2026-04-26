using ProyectoIProgra2.Data;
using ProyectoIProgra2.Entidades;

namespace ProyectoIProgra2.Servicios
{
    public class ListaDeEsperaServicio : IListaDeEsperaServicio
    {
        private readonly MyAppDbContext _MyAppDbContext;
        public ListaDeEsperaServicio(MyAppDbContext myAppDbContext)
        {
            _MyAppDbContext = myAppDbContext;
        }
        public ListaDeEspera ActualizarListaDeEspera(int listaId, ListaDeEspera lista)
        {
            var result = _MyAppDbContext.ListasDeEspera.Find(listaId);
            result.ListaDeEsperaId = lista.ListaDeEsperaId;
            _MyAppDbContext.ListasDeEspera.Update(result);
            _MyAppDbContext.SaveChanges();
            return result;
        }

        public ListaDeEspera AsignarMesaDesdeLista(int listaId, int mesaId)
        {
            throw new NotImplementedException();
        }

        public ListaDeEspera BuscarPorId(int listaId)
        {
            var result = _MyAppDbContext.ListasDeEspera.Find(listaId);
            return result;
        }

        public ListaDeEspera CambiarEstadoLista(int listaId, int estadoId)
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

        public void EliminarListaDeEspera(int listaId)
        {
            var result = _MyAppDbContext.ListasDeEspera.Find(listaId);
            _MyAppDbContext.ListasDeEspera.Remove(result);
            _MyAppDbContext.SaveChanges();
        }

        public bool HayPersonasEnListaDeEspera(int turnoId)
        {
            throw new NotImplementedException();
        }

        public List<ListaDeEspera> ListarListaEspera()
        {
            return _MyAppDbContext.ListasDeEspera.ToList();
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
