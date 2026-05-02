using Microsoft.EntityFrameworkCore;
using ProyectoIProgra2.Entidades;

namespace ProyectoIProgra2.Data
{

    public class MyAppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("MyAppDb");
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Zona> Zonas { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<EstadoDeReserva> EstadoDeReservas { get; set; }
        public DbSet<BloqueoMesa> BloqueosMesas { get; set; }
        public DbSet<ListaDeEspera> ListasDeEspera { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ZONAS
            modelBuilder.Entity<Zona>().HasData(
                new Zona { ZonaId = 1, Seccion = "Interior" },
                new Zona { ZonaId = 2, Seccion = "Terraza" },
                new Zona { ZonaId = 3, Seccion = "Jardín" },
                new Zona { ZonaId = 4, Seccion = "VIP" }
            );

            // MESAS
            modelBuilder.Entity<Mesa>().HasData(
                new Mesa { MesaId = 1, Capacidad = 4, ZonaId = 1 },
                new Mesa { MesaId = 2, Capacidad = 2, ZonaId = 1 },
                new Mesa { MesaId = 3, Capacidad = 6, ZonaId = 1 },
                new Mesa { MesaId = 4, Capacidad = 4, ZonaId = 2 },
                new Mesa { MesaId = 5, Capacidad = 2, ZonaId = 2 },
                new Mesa { MesaId = 6, Capacidad = 8, ZonaId = 2 },
                new Mesa { MesaId = 7, Capacidad = 4, ZonaId = 3 },
                new Mesa { MesaId = 8, Capacidad = 6, ZonaId = 3 },
                new Mesa { MesaId = 9, Capacidad = 4, ZonaId = 4 },
                new Mesa { MesaId = 10, Capacidad = 8, ZonaId = 4 }
            );

            // TURNOS (solo una vez ✅)
            modelBuilder.Entity<Turno>().HasData(
                new Turno { TurnoId = 1, HoraInicio = 8, HoraFin = 11 },
                new Turno { TurnoId = 2, HoraInicio = 12, HoraFin = 15 },
                new Turno { TurnoId = 3, HoraInicio = 18, HoraFin = 22 }
            );

            // CLIENTES
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente { ClienteId = 1, Ced = 101110111, Nombre = "Juan", Apellidos = "Pérez López", Tel = 88881111, Email = "juan@email.com" },
                new Cliente { ClienteId = 2, Ced = 202220222, Nombre = "María", Apellidos = "González Mora", Tel = 88882222, Email = "maria@email.com" },
                new Cliente { ClienteId = 3, Ced = 303330333, Nombre = "Carlos", Apellidos = "Rodríguez Soto", Tel = 88883333, Email = "carlos@email.com" },
                new Cliente { ClienteId = 4, Ced = 404440444, Nombre = "Ana", Apellidos = "Martínez Cruz", Tel = 88884444, Email = "ana@email.com" },
                new Cliente { ClienteId = 5, Ced = 505550555, Nombre = "Luis", Apellidos = "Hernández Vega", Tel = 88885555, Email = "luis@email.com" }
            );

            // ESTADOS DE RESERVA
            modelBuilder.Entity<EstadoDeReserva>().HasData(
                new EstadoDeReserva { EstadoDeReservaId = 1, Estado = "Activa" },
                new EstadoDeReserva { EstadoDeReservaId = 2, Estado = "Cancelada" },
                new EstadoDeReserva { EstadoDeReservaId = 3, Estado = "Atendida" }
            );

            // BLOQUEOS (solo una vez ✅)
            modelBuilder.Entity<BloqueoMesa>().HasData(
                new BloqueoMesa
                {
                    BloqueoMesaId = 1,
                    MesaId = 2,
                    Fecha = new DateTime(2025, 6, 15),
                    HoraInicio = new DateTime(2025, 6, 15, 8, 0, 0),
                    HoraFin = new DateTime(2025, 6, 15, 22, 0, 0),
                    Detalle = "Mantenimiento de mesa"
                },
                new BloqueoMesa
                {
                    BloqueoMesaId = 2,
                    MesaId = 6,
                    Fecha = new DateTime(2025, 6, 16),
                    HoraInicio = new DateTime(2025, 6, 16, 18, 0, 0),
                    HoraFin = new DateTime(2025, 6, 16, 22, 0, 0),
                    Detalle = "Evento privado"
                },
                new BloqueoMesa
                {
                    BloqueoMesaId = 3,
                    MesaId = 10,
                    Fecha = new DateTime(2025, 6, 15),
                    HoraInicio = new DateTime(2025, 6, 15, 8, 0, 0),
                    HoraFin = new DateTime(2025, 6, 15, 11, 0, 0),
                    Detalle = "Limpieza profunda"
                }
            );

            // RESERVAS
            modelBuilder.Entity<Reserva>().HasData(
                new Reserva
                {
                    ReservaId = 1,
                    ClienteId = 1,
                    MesaId = 1,
                    TurnoId = 2,
                    EstadoDeReservaId = 1,
                    CantidaPersonas = 3,
                    Fecha = new DateTime(2025, 6, 15),
                    HoraInicio = new DateTime(2025, 6, 15, 12, 0, 0),
                    HoraFin = new DateTime(2025, 6, 15, 15, 0, 0)
                },
                new Reserva
                {
                    ReservaId = 2,
                    ClienteId = 2,
                    MesaId = 4,
                    TurnoId = 3,
                    EstadoDeReservaId = 1,
                    CantidaPersonas = 2,
                    Fecha = new DateTime(2025, 6, 15),
                    HoraInicio = new DateTime(2025, 6, 15, 18, 0, 0),
                    HoraFin = new DateTime(2025, 6, 15, 22, 0, 0)
                }
            );

            // LISTA DE ESPERA
            modelBuilder.Entity<ListaDeEspera>().HasData(
                new ListaDeEspera
                {
                    ListaDeEsperaId = 1,
                    ClienteId = 3,
                    TurnoId = 2,
                    CantidadPersonas = 4,
                    HoraSolicitud = new DateTime(2025, 6, 15, 11, 30, 0)
                },
                new ListaDeEspera
                {
                    ListaDeEsperaId = 2,
                    ClienteId = 4,
                    TurnoId = 3,
                    CantidadPersonas = 2,
                    HoraSolicitud = new DateTime(2025, 6, 15, 17, 0, 0)
                }
            );
        }

    }
}
    