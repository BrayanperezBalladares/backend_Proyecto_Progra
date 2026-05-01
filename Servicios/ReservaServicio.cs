using ProyectoIProgra2.Data;
using ProyectoIProgra2.Entidades;

namespace ProyectoIProgra2.Servicios
{
    public class ReservaServicio : IReservaServicio
    {
        private readonly MyAppDbContext _MyAppDbContext;

        public ReservaServicio(MyAppDbContext myAppDbContext)
        {
            _MyAppDbContext = myAppDbContext;
        }
        public Reserva ActualizarReserva(int reservaId, Reserva reserva)
        {
        var result = _MyAppDbContext.Reservas.Find(reservaId);
         if (result == null)
         throw new Exception("Reserva no encontrada");

         if (result.EstadoDeReservaId != 1)
         throw new Exception("Solo se pueden modificar reservas en estado Activo");

         bool cambioHorarioMesa = result.MesaId != reserva.MesaId ||
         result.HoraInicio != reserva.HoraInicio ||
         result.HoraFin != reserva.HoraFin;

        if (cambioHorarioMesa)
        {
        if (!ComprobarDisponibilidadDeReservas(reserva.MesaId, reserva.HoraInicio, reserva.HoraFin))
        throw new Exception("La mesa no está disponible en el nuevo horario");

        bool bloqueada = _MyAppDbContext.BloqueosMesas.Any(b =>
        b.MesaId == reserva.MesaId &&
        reserva.HoraInicio < b.HoraFin &&
        reserva.HoraFin > b.HoraInicio
        );

        if (bloqueada)
        throw new Exception("La mesa está bloqueada en el nuevo horario");
        }
        result.Fecha = reserva.Fecha;
        result.HoraInicio = reserva.HoraInicio;
        result.HoraFin = reserva.HoraFin;
        result.CantidaPersonas = reserva.CantidaPersonas;
        result.MesaId = reserva.MesaId;

         _MyAppDbContext.Update(result);
         _MyAppDbContext.SaveChanges();

        return result;
        }

        public Reserva AsignarMesa(int reservaId, int mesaId)
        {
            var reserva = _MyAppDbContext.Reservas.Find(reservaId);
            if (reserva == null)
                throw new Exception("Reserva no encontrada");

            if (!ComprobarDisponibilidadDeReservas(mesaId, reserva.HoraInicio, reserva.HoraFin))
                throw new Exception("Mesa no disponible");

            bool bloqueada = _MyAppDbContext.BloqueosMesas.Any(b =>
                b.MesaId == mesaId &&
                reserva.HoraInicio < b.HoraFin &&
                reserva.HoraFin > b.HoraInicio
            );

            if (bloqueada)
                throw new Exception("La mesa está bloqueada en ese horario");

            reserva.MesaId = mesaId;
            _MyAppDbContext.Update(reserva);
            _MyAppDbContext.SaveChanges();

            return reserva;
        }

        public Reserva BuscarReservaPorId(int reservaId)
        {
        var result = _MyAppDbContext.Reservas.Find(reservaId);
         if (result == null)
         throw new Exception("Reserva no encontrada");
         return result;
        }

        public List<Reserva> BuscarReservasPorEstadoId(int estadoId)
        {
        return _MyAppDbContext.Reservas
        .Where(r => r.EstadoDeReservaId == estadoId)
        .ToList();
        }

        public Reserva CambiarEstadoReserva(int reservaId, int estadoId)
        {
            var reserva = _MyAppDbContext.Reservas.Find(reservaId);
            if (reserva == null)
                throw new Exception("Reserva no encontrada");

            var estadoActual = _MyAppDbContext.EstadoDeReservas.Find(reserva.EstadoDeReservaId);
            var estadoNuevo = _MyAppDbContext.EstadoDeReservas.Find(estadoId);
            if (estadoActual == null)
                throw new Exception("El estado actual no existe");

            if (estadoNuevo == null)
                throw new Exception("El estado indicado no existe");

            if (estadoActual.Estado == "Cancelada" && estadoNuevo.Estado == "Atendida")
                throw new Exception("No se puede cambiar de Cancelada a Atendida");

            if (estadoActual.Estado == "Atendida")
                throw new Exception("Una reserva Atendida no puede cambiar de estado");

            reserva.EstadoDeReservaId = estadoId;

            _MyAppDbContext.Update(reserva);
            _MyAppDbContext.SaveChanges();

            if (estadoNuevo.Estado == "Atendida")
            ProcesarListaDeEspera(reserva.MesaId, reserva.HoraInicio, reserva.HoraFin);

            return reserva;
        }

        public Reserva CancelarReserva(int reservaId)
        {
            var reserva = _MyAppDbContext.Reservas.Find(reservaId);
            if (reserva == null)
                throw new Exception("Reserva no encontrada");

            if (reserva.EstadoDeReservaId == 2)
                throw new Exception("La reserva ya está cancelada");

            if (reserva.EstadoDeReservaId == 3)
                throw new Exception("No se puede cancelar una reserva ya Atendida");

            reserva.EstadoDeReservaId = 2;
            _MyAppDbContext.Update(reserva);
            _MyAppDbContext.SaveChanges();

            ProcesarListaDeEspera(reserva.MesaId, reserva.HoraInicio, reserva.HoraFin);

            return reserva;
        }

        public bool ComprobarDisponibilidadDeReservas(int mesaId, DateTime inicio, DateTime fin)
        {
            bool sinReservas = !_MyAppDbContext.Reservas.Any(r =>
               r.MesaId == mesaId &&
               r.EstadoDeReservaId != 2 &&
               inicio < r.HoraFin &&
               fin > r.HoraInicio
           );
            bool sinBloqueos = !_MyAppDbContext.BloqueosMesas.Any(b =>
                b.MesaId == mesaId &&
                inicio < b.HoraFin &&
                fin > b.HoraInicio
            );

            return sinReservas && sinBloqueos;
        }

        public Reserva CrearReserva(Reserva reserva)
        {
            if (!ValidarReserva(reserva))
                throw new Exception("Reserva inválida: verifique cliente, mesa, horario y capacidad");

            bool mesaBloqueada = _MyAppDbContext.BloqueosMesas.Any(b =>
                b.MesaId == reserva.MesaId &&
                reserva.HoraInicio < b.HoraFin &&
                reserva.HoraFin > b.HoraInicio
            );

            if (mesaBloqueada)
                throw new Exception("La mesa está bloqueada en ese horario");

            reserva.EstadoDeReservaId = 1;

            _MyAppDbContext.Reservas.Add(reserva);
            _MyAppDbContext.SaveChanges();

            return reserva;
        }

        public void EliminarReserva(int reservaId)
        {
            var result = _MyAppDbContext.Reservas.Find(reservaId);
            if (result == null)
                throw new Exception("Reserva no encontrada");

            if (result.EstadoDeReservaId == 1)
                throw new Exception("Debes cancelar la reserva antes de eliminarla");

            _MyAppDbContext.Reservas.Remove(result);
            _MyAppDbContext.SaveChanges();
        }

        public bool EstaDentroDeTurno(DateTime inicio, DateTime fin)
        {
            int horaInicio = inicio.Hour;
            int horaFin = fin.Hour;

            return _MyAppDbContext.Turnos.Any(t =>
                t.HoraInicio <= horaInicio &&
                t.HoraFin >= horaFin
            );
        }

        public List<Reserva> ListarReservas()
        {
            return _MyAppDbContext.Reservas.ToList();
        }

        public List<Reserva> ObtenerReservaPorClienteId(int clienteId)
        {
            return _MyAppDbContext.Reservas
                .Where(r => r.ClienteId == clienteId)
                .ToList();
        }

        public List<Reserva> ObtenerReservasPorFecha(DateTime fecha)
        {
            return _MyAppDbContext.Reservas
            .Where(r => r.Fecha.Date == fecha.Date)
             .ToList();
        }

        public void ProcesarListaDeEspera(int mesaId, DateTime inicio, DateTime fin)
        {
            var mesa = _MyAppDbContext.Mesas.Find(mesaId);
            if (mesa == null) return;

            var lista = _MyAppDbContext.ListasDeEspera
                .OrderBy(l => l.HoraSolicitud)
                .ToList();

            foreach (var persona in lista)
            {
                if (persona.CantidadPersonas > mesa.Capacidad)
                    continue;

                if (!ComprobarDisponibilidadDeReservas(mesaId, inicio, fin))
                    break;

                var nuevaReserva = new Reserva
                {
                    ClienteId = persona.ClienteId,
                    MesaId = mesaId,
                    Fecha = inicio.Date,
                    HoraInicio = inicio,
                    HoraFin = fin,
                    CantidaPersonas = persona.CantidadPersonas,
                    EstadoDeReservaId = 1
                };

                _MyAppDbContext.Reservas.Add(nuevaReserva);
                _MyAppDbContext.ListasDeEspera.Remove(persona);
                _MyAppDbContext.SaveChanges();

                break;
            }
            }

        public bool ValidarReserva(Reserva reserva)
        {
          if (reserva.HoraInicio >= reserva.HoraFin)
                return false;

          var cliente = _MyAppDbContext.Clientes.Find(reserva.ClienteId);
          if (cliente == null)
                return false;

          if (cliente.Ced == 0 || cliente.Tel == 0)
          return false;
            
          var mesa = _MyAppDbContext.Mesas.Find(reserva.MesaId);
          if (mesa == null || mesa.Capacidad < reserva.CantidaPersonas)
          return false;

          if (!EstaDentroDeTurno(reserva.HoraInicio, reserva.HoraFin))
          return false;
            
         if (!ComprobarDisponibilidadDeReservas(reserva.MesaId, reserva.HoraInicio, reserva.HoraFin))
         return false;

         return true;
        }
    }
}
