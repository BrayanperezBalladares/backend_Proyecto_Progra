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

            if (result == null)
                throw new Exception("Entrada en lista de espera no encontrada");

            result.ClienteId = lista.ClienteId;
            result.TurnoId = lista.TurnoId;
            result.CantidadPersonas = lista.CantidadPersonas;
            result.HoraSolicitud = lista.HoraSolicitud;

            _MyAppDbContext.Update(result);
            _MyAppDbContext.SaveChanges();
            return result;
        }

        public ListaDeEspera BuscarPorId(int listaId)
        {
            var result = _MyAppDbContext.ListasDeEspera.Find(listaId);

            if (result == null)
                throw new Exception("Entrada de lista de espera no encontrada");

            return result;
        }

        public Reserva ConvertirAReserva(int listaId, int mesaId)
        {
            var lista = _MyAppDbContext.ListasDeEspera.Find(listaId);
            if (lista == null)
                throw new Exception("Entrada de lista de espera no encontrada");

            var mesa = _MyAppDbContext.Mesas.Find(mesaId);
            if (mesa == null)
                throw new Exception("La mesa no existe");

            if (lista.CantidadPersonas > mesa.Capacidad)
                throw new Exception("La mesa no tiene capacidad suficiente");

            var turno = _MyAppDbContext.Turnos.Find(lista.TurnoId);
            if (turno == null)
                throw new Exception("El turno no existe");

            // Usar directamente las horas del turno
            DateTime horaInicio = turno.HorarioInicio; 
            DateTime horaFin = turno.HorarioFin;    

            bool mesaDisponible = !_MyAppDbContext.Reservas.Any(r =>
                r.MesaId == mesaId &&
                r.EstadoDeReservaId != 2 &&
                horaInicio < r.HoraFin &&
                horaFin > r.HoraInicio
            );

            if (!mesaDisponible)
                throw new Exception("La mesa no está disponible en ese horario");

            var nuevaReserva = new Reserva
            {
                ClienteId = lista.ClienteId,
                MesaId = mesaId,
                Fecha = DateTime.Today,
                HoraInicio = horaInicio,
                HoraFin = horaFin,
                CantidaPersonas = lista.CantidadPersonas,
                EstadoDeReservaId = 1
            };

            _MyAppDbContext.Reservas.Add(nuevaReserva);
            _MyAppDbContext.ListasDeEspera.Remove(lista); 
            _MyAppDbContext.SaveChanges();

            return nuevaReserva;

        }

        public ListaDeEspera CrearListaDeEspera(ListaDeEspera lista)
        {
            _MyAppDbContext.ListasDeEspera.Add(lista);
            _MyAppDbContext.SaveChanges();
            return lista;
        }

        public void EliminarClienteEnListaDeEspera(int listaId)
        {
            var result = _MyAppDbContext.ListasDeEspera.Find(listaId);
            if (result == null)
                throw new Exception("Entrada en lista de espera no encontrada");
            _MyAppDbContext.ListasDeEspera.Remove(result);
            _MyAppDbContext.SaveChanges();
        }

        public bool HayPersonasEnEspera(int turnoId)
        {
            return _MyAppDbContext.ListasDeEspera
                .Any(l => l.TurnoId == turnoId);
        }

        public List<ListaDeEspera> ListarListaEspera()
        {
            throw new NotImplementedException();
        }

        public List<ListaDeEspera> ObtenerListaPorTurno(int turnoId)
        {
            throw new NotImplementedException();
        }

        public ListaDeEspera ObtenerSiguienteEnEspera(int turnoId)
        {
            throw new NotImplementedException();
        }
    }
}
