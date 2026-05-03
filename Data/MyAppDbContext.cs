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
            // Zonas
            modelBuilder.Entity<Zona>().HasData(
                new Zona { ZonaId = 1, Seccion = "Interior" },
                new Zona { ZonaId = 2, Seccion = "Terraza" },
                new Zona { ZonaId = 3, Seccion = "Jardín" },
                new Zona { ZonaId = 4, Seccion = "VIP" }
            );

            // Mesas
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

            // Turnos
            modelBuilder.Entity<Turno>().HasData(
                new Turno { TurnoId = 1, HoraInicio = 8, HoraFin = 11 },//Desayuno
                new Turno { TurnoId = 2, HoraInicio = 12, HoraFin = 15 },//Almuerzo
                new Turno { TurnoId = 3, HoraInicio = 18, HoraFin = 22 }//Cena
            );

            // Estados de reservas
            modelBuilder.Entity<EstadoDeReserva>().HasData(
                new EstadoDeReserva { EstadoDeReservaId = 1, Estado = "Activa" },
                new EstadoDeReserva { EstadoDeReservaId = 2, Estado = "Cancelada" },
                new EstadoDeReserva { EstadoDeReservaId = 3, Estado = "Atendida" }
            );

        }
    }
}
    