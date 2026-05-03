using ProyectoIProgra2.Data;
using ProyectoIProgra2.DTOs;
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

        public ListaDeEsperaDto ActualizarListaDeEspera(int listaId, ListaDeEsperaDto dto)
        {
            var result = _MyAppDbContext.ListasDeEspera.Find(listaId);

            if (result == null)
                throw new Exception("Entrada en lista de espera no encontrada");

            result.ClienteId = dto.ClienteId;
            result.TurnoId = dto.TurnoId;
            result.CantidadPersonas = dto.CantidadPersonas;
            

            _MyAppDbContext.Update(result);
            _MyAppDbContext.SaveChanges();
            return dto;

        }

        public ListaDeEsperaDto BuscarPorId(int listaId)
        {
            var result = _MyAppDbContext.ListasDeEspera.Find(listaId);

            if (result == null)
                throw new Exception("Entrada de lista de espera no encontrada");

            return new ListaDeEsperaDto
            {
                ClienteId = result.ClienteId,
                TurnoId = result.TurnoId,
                CantidadPersonas = result.CantidadPersonas
            };
        }

        public ReservaDto ConvertirAReserva(int listaId, int mesaId)
        {
            var lista = _MyAppDbContext.ListasDeEspera.Find(listaId);
            if (lista == null)
                throw new Exception("Entrada de lista de espera no encontrada");

            var turno = _MyAppDbContext.Turnos.Find(lista.TurnoId);
            if (turno == null)
                throw new Exception("El turno no existe");

            if (!HayPersonasEnEspera(lista.TurnoId))
                throw new Exception("No hay personas en espera para ese turno");

            var mesa = _MyAppDbContext.Mesas.Find(mesaId);
            if (mesa == null)
                throw new Exception("La mesa no existe");

            var siguiente = ObtenerSiguienteEnEspera(lista.TurnoId, mesa.Capacidad);
            if (siguiente.ListaDeEsperaId != listaId)
                throw new Exception("No es el siguiente en la lista que cumple con la capacidad de esa mesa");

            DateTime horaInicio = DateTime.Today.AddHours(turno.HoraInicio);
            DateTime horaFin = DateTime.Today.AddHours(turno.HoraFin);

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
                EstadoDeReservaId = 1,
                TurnoId = lista.TurnoId
            };

            _MyAppDbContext.Reservas.Add(nuevaReserva);

            _MyAppDbContext.ListasDeEspera.Remove(lista);
            _MyAppDbContext.SaveChanges();

            return new ReservaDto
            {
                ReservaId = nuevaReserva.ReservaId,
                ClienteId = nuevaReserva.ClienteId,
                MesaId = nuevaReserva.MesaId,
                TurnoId = nuevaReserva.TurnoId,
                CantidadPersonas = nuevaReserva.CantidaPersonas,
                Fecha = nuevaReserva.Fecha,
                HoraInicio = nuevaReserva.HoraInicio,
                HoraFin = nuevaReserva.HoraFin
            };


        }

        public ListaDeEspera CrearListaDeEspera(ListaDeEspera lista)
        {
            var cliente = _MyAppDbContext.Clientes.Find(lista.ClienteId);
            if (cliente == null)
                throw new Exception("El cliente no existe");

            var turno = _MyAppDbContext.Turnos.Find(lista.TurnoId);
            if (turno == null)
                throw new Exception("El turno no existe");

            if (lista.CantidadPersonas <= 0)
                throw new Exception("La cantidad de personas debe ser mayor a 0");

            lista.HoraSolicitud = DateTime.Now;

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

        public List<ListaDeEsperaDto> ListarListaEspera()
        {
            return _MyAppDbContext.ListasDeEspera
                .OrderBy(l => l.HoraSolicitud)
                .Select(l => new ListaDeEsperaDto
                {
                    ClienteId = l.ClienteId,
                    TurnoId = l.TurnoId,
                    CantidadPersonas = l.CantidadPersonas
                })
                .ToList();
        }

        public List<ListaDeEsperaDto> ObtenerListaPorTurno(int turnoId)
        {
            return _MyAppDbContext.ListasDeEspera
                .Where(l => l.TurnoId == turnoId)
                .OrderBy(l => l.HoraSolicitud)
                .Select(l => new ListaDeEsperaDto
                {
                    ClienteId = l.ClienteId,
                    TurnoId = l.TurnoId,
                    CantidadPersonas = l.CantidadPersonas
                })
                .ToList();
        }


        public ListaDeEspera ObtenerSiguienteEnEspera(int turnoId, int capacidadMesa)
        {
        var result = _MyAppDbContext.ListasDeEspera
        .Where(P => P.TurnoId == turnoId &&
        P.CantidadPersonas <= capacidadMesa)
        .OrderBy(P => P.HoraSolicitud)
        .FirstOrDefault();

        if (result == null)
        throw new Exception("No cumplen con la capacidad de la mesa");

            return result;
        }
    }
}
