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
            // Zonas del restaurante
            modelBuilder.Entity<Zona>().HasData(
                new Zona { ZonaId = 1, Seccion = "Interior" },
                new Zona { ZonaId = 2, Seccion = "Terraza" },
                new Zona { ZonaId = 3, Seccion = "Jardín" }
            );

            // Mesas del restaurante
            modelBuilder.Entity<Mesa>().HasData(
                new Mesa { MesaId = 1, NumMesa = 1, Capacidad = 4, ZonaId = 1 },
                new Mesa { MesaId = 2, NumMesa = 2, Capacidad = 2, ZonaId = 1 },
                new Mesa { MesaId = 3, NumMesa = 3, Capacidad = 6, ZonaId = 2 },
                new Mesa { MesaId = 4, NumMesa = 4, Capacidad = 4, ZonaId = 3 }
            );

            // Clientes de ejemplo
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente { ClienteId = 1, Ced = 101110111, Nombre = "Juan", Apellidos = "Pérez López", Tel = 88881111, Email = "juan@email.com" },
                new Cliente { ClienteId = 2, Ced = 202220222, Nombre = "María", Apellidos = "González Mora", Tel = 88882222, Email = "maria@email.com" }
            );


            // Estados posibles de una reserva
            modelBuilder.Entity<EstadoDeReserva>().HasData(
                new EstadoDeReserva { EstadoDeReservaId = 1, Estado = "Pendiente" },
                new EstadoDeReserva { EstadoDeReservaId = 2, Estado = "Confirmada" },
                new EstadoDeReserva { EstadoDeReservaId = 3, Estado = "Cancelada" },
                new EstadoDeReserva { EstadoDeReservaId = 4, Estado = "Completada" }
            );

            // Turnos del restaurante
            modelBuilder.Entity<Turno>().HasData(
                new Turno { TurnoId = 1, HorarioIncio = new DateTime(2025, 1, 1, 12, 0, 0), HorarioFin = new DateTime(2025, 1, 1, 15, 0, 0) },
                new Turno { TurnoId = 2, HorarioIncio = new DateTime(2025, 1, 1, 18, 0, 0), HorarioFin = new DateTime(2025, 1, 1, 22, 0, 0) }
            );

            modelBuilder.Entity<Reserva>().HasData(
                new Reserva
                {
                    ReservaId = 1,
                    ClienteId = 1,         
                    MesaId = 1,             
                    TurnoId = 1,           
                    EstadoDeReservaId = 2,  
                    CantidaPersonas = 3,
                    Fecha = new DateTime(2025, 6, 15),
                    HoraInicio = new DateTime(2025, 6, 15, 12, 0, 0),
                    HoraFin = new DateTime(2025, 6, 15, 14, 0, 0)
                }
            );


        }

    }
}


























