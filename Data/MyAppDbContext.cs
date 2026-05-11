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

            //Clientes
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente { ClienteId = 1, Ced = 101110111, Nombre = "Juan", Apellidos = "Pérez López", Tel = 88881111, Email = "juan@email.com" },
                new Cliente { ClienteId = 2, Ced = 202220222, Nombre = "María", Apellidos = "González Mora", Tel = 88882222, Email = "maria@email.com" },
                new Cliente { ClienteId = 3, Ced = 303330333, Nombre = "Carlos", Apellidos = "Rodríguez Soto", Tel = 88883333, Email = "carlos@email.com" },
                new Cliente { ClienteId = 4, Ced = 404440444, Nombre = "Ana", Apellidos = "Martínez Cruz", Tel = 88884444, Email = "ana@email.com" },
                new Cliente { ClienteId = 5, Ced = 505550555, Nombre = "Luis", Apellidos = "Hernández Vega", Tel = 88885555, Email = "luis@email.com" },
                new Cliente { ClienteId = 6, Ced = 606660666, Nombre = "Sofía", Apellidos = "Ramírez Quirós", Tel = 88886666, Email = "sofia@email.com" },
                new Cliente { ClienteId = 7, Ced = 707770777, Nombre = "Diego", Apellidos = "Vargas Jiménez", Tel = 88887777, Email = "diego@email.com" },
                new Cliente { ClienteId = 8, Ced = 808880888, Nombre = "Valeria", Apellidos = "Castro Solano", Tel = 88888888, Email = "valeria@email.com" },
                new Cliente { ClienteId = 9, Ced = 909990999, Nombre = "Andrés", Apellidos = "Mora Brenes", Tel = 88889999, Email = "andres@email.com" },
                new Cliente { ClienteId = 10, Ced = 101010101, Nombre = "Camila", Apellidos = "Rojas Campos", Tel = 88880000, Email = "camila@email.com" },
                new Cliente { ClienteId = 11, Ced = 111111110, Nombre = "Sebastián", Apellidos = "Núñez Alfaro", Tel = 87771111, Email = "sebastian@email.com" },
                new Cliente { ClienteId = 12, Ced = 121212120, Nombre = "Isabella", Apellidos = "Flores Madrigal", Tel = 87772222, Email = "isabella@email.com" },
                new Cliente { ClienteId = 13, Ced = 131313130, Nombre = "Mateo", Apellidos = "Chaves Araya", Tel = 87773333, Email = "mateo@email.com" },
                new Cliente { ClienteId = 14, Ced = 141414140, Nombre = "Daniela", Apellidos = "Segura Monge", Tel = 87774444, Email = "daniela@email.com" },
                new Cliente { ClienteId = 15, Ced = 151515150, Nombre = "Gabriel", Apellidos = "Herrera Vindas", Tel = 87775555, Email = "gabriel@email.com" }
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

            // TURNOS (solo una vez)
            modelBuilder.Entity<Turno>().HasData(
                new Turno { TurnoId = 1, HoraInicio = 8, HoraFin = 11 },
                new Turno { TurnoId = 2, HoraInicio = 12, HoraFin = 17 },
                new Turno { TurnoId = 3, HoraInicio = 18, HoraFin = 22 }
            );

            //Reservas
            modelBuilder.Entity<Reserva>().HasData(
                new Reserva { ReservaId = 1, ClienteId = 1, MesaId = 1, TurnoId = 2, EstadoDeReservaId = 1, CantidaPersonas = 3, Fecha = new DateTime(2026, 6, 15), HoraInicio = new DateTime(2026, 6, 15, 12, 0, 0), HoraFin = new DateTime(2026, 6, 15, 15, 0, 0) },
                new Reserva { ReservaId = 2, ClienteId = 2, MesaId = 4, TurnoId = 3, EstadoDeReservaId = 1, CantidaPersonas = 2, Fecha = new DateTime(2026, 6, 15), HoraInicio = new DateTime(2026, 6, 15, 18, 0, 0), HoraFin = new DateTime(2026, 6, 15, 22, 0, 0) },
                new Reserva { ReservaId = 3, ClienteId = 3, MesaId = 7, TurnoId = 1, EstadoDeReservaId = 1, CantidaPersonas = 4, Fecha = new DateTime(2026, 6, 16), HoraInicio = new DateTime(2026, 6, 16, 8, 0, 0), HoraFin = new DateTime(2026, 6, 16, 11, 0, 0) },
                new Reserva { ReservaId = 4, ClienteId = 4, MesaId = 3, TurnoId = 2, EstadoDeReservaId = 1, CantidaPersonas = 5, Fecha = new DateTime(2026, 6, 16), HoraInicio = new DateTime(2026, 6, 16, 12, 0, 0), HoraFin = new DateTime(2026, 6, 16, 15, 0, 0) },
                new Reserva { ReservaId = 5, ClienteId = 5, MesaId = 5, TurnoId = 3, EstadoDeReservaId = 1, CantidaPersonas = 2, Fecha = new DateTime(2026, 6, 16), HoraInicio = new DateTime(2026, 6, 16, 18, 0, 0), HoraFin = new DateTime(2026, 6, 16, 22, 0, 0) },
                new Reserva { ReservaId = 6, ClienteId = 6, MesaId = 8, TurnoId = 1, EstadoDeReservaId = 1, CantidaPersonas = 6, Fecha = new DateTime(2026, 6, 17), HoraInicio = new DateTime(2026, 6, 17, 8, 0, 0), HoraFin = new DateTime(2026, 6, 17, 11, 0, 0) },
                new Reserva { ReservaId = 7, ClienteId = 7, MesaId = 9, TurnoId = 2, EstadoDeReservaId = 1, CantidaPersonas = 4, Fecha = new DateTime(2026, 6, 17), HoraInicio = new DateTime(2026, 6, 17, 12, 0, 0), HoraFin = new DateTime(2026, 6, 17, 15, 0, 0) },
                new Reserva { ReservaId = 8, ClienteId = 8, MesaId = 6, TurnoId = 1, EstadoDeReservaId = 1, CantidaPersonas = 7, Fecha = new DateTime(2026, 6, 17), HoraInicio = new DateTime(2026, 6, 17, 8, 0, 0), HoraFin = new DateTime(2026, 6, 17, 11, 0, 0) },
                new Reserva { ReservaId = 9, ClienteId = 9, MesaId = 10, TurnoId = 2, EstadoDeReservaId = 1, CantidaPersonas = 4, Fecha = new DateTime(2026, 6, 18), HoraInicio = new DateTime(2026, 6, 18, 12, 0, 0), HoraFin = new DateTime(2026, 6, 18, 15, 0, 0) },
                new Reserva { ReservaId = 10, ClienteId = 10, MesaId = 2, TurnoId = 3, EstadoDeReservaId = 2, CantidaPersonas = 2, Fecha = new DateTime(2026, 6, 18), HoraInicio = new DateTime(2026, 6, 18, 18, 0, 0), HoraFin = new DateTime(2026, 6, 18, 22, 0, 0) },
                new Reserva { ReservaId = 11, ClienteId = 11, MesaId = 1, TurnoId = 1, EstadoDeReservaId = 1, CantidaPersonas = 3, Fecha = new DateTime(2026, 6, 18), HoraInicio = new DateTime(2026, 6, 18, 8, 0, 0), HoraFin = new DateTime(2026, 6, 18, 11, 0, 0) },
                new Reserva { ReservaId = 12, ClienteId = 12, MesaId = 4, TurnoId = 2, EstadoDeReservaId = 1, CantidaPersonas = 4, Fecha = new DateTime(2026, 6, 19), HoraInicio = new DateTime(2026, 6, 19, 12, 0, 0), HoraFin = new DateTime(2026, 6, 19, 15, 0, 0) },
                new Reserva { ReservaId = 13, ClienteId = 13, MesaId = 7, TurnoId = 3, EstadoDeReservaId = 3, CantidaPersonas = 3, Fecha = new DateTime(2026, 6, 19), HoraInicio = new DateTime(2026, 6, 19, 18, 0, 0), HoraFin = new DateTime(2026, 6, 19, 22, 0, 0) },
                new Reserva { ReservaId = 14, ClienteId = 14, MesaId = 3, TurnoId = 1, EstadoDeReservaId = 1, CantidaPersonas = 6, Fecha = new DateTime(2026, 6, 20), HoraInicio = new DateTime(2026, 6, 20, 8, 0, 0), HoraFin = new DateTime(2026, 6, 20, 11, 0, 0) },
                new Reserva { ReservaId = 15, ClienteId = 15, MesaId = 5, TurnoId = 2, EstadoDeReservaId = 1, CantidaPersonas = 2, Fecha = new DateTime(2026, 6, 20), HoraInicio = new DateTime(2026, 6, 20, 12, 0, 0), HoraFin = new DateTime(2026, 6, 20, 15, 0, 0) },
                new Reserva { ReservaId = 16, ClienteId = 15, MesaId = 9, TurnoId = 3, EstadoDeReservaId = 1, CantidaPersonas = 4, Fecha = new DateTime(2026, 6, 20), HoraInicio = new DateTime(2026, 6, 20, 18, 0, 0), HoraFin = new DateTime(2026, 6, 20, 22, 0, 0) }
            );

            //Listas de espera
            modelBuilder.Entity<ListaDeEspera>().HasData(
                new ListaDeEspera { ListaDeEsperaId = 1, ClienteId = 3, TurnoId = 2, CantidadPersonas = 4, HoraSolicitud = new DateTime(2026, 6, 15, 11, 30, 0) },
                new ListaDeEspera { ListaDeEsperaId = 2, ClienteId = 4, TurnoId = 3, CantidadPersonas = 2, HoraSolicitud = new DateTime(2026, 6, 15, 17, 0, 0) },
                new ListaDeEspera { ListaDeEsperaId = 3, ClienteId = 6, TurnoId = 1, CantidadPersonas = 3, HoraSolicitud = new DateTime(2026, 6, 16, 7, 45, 0) },
                new ListaDeEspera { ListaDeEsperaId = 4, ClienteId = 9, TurnoId = 2, CantidadPersonas = 5, HoraSolicitud = new DateTime(2026, 6, 17, 11, 0, 0) },
                new ListaDeEspera { ListaDeEsperaId = 5, ClienteId = 12, TurnoId = 3, CantidadPersonas = 2, HoraSolicitud = new DateTime(2026, 6, 18, 17, 30, 0) }
            );

            // ESTADOS DE RESERVA
            modelBuilder.Entity<EstadoDeReserva>().HasData(
                new EstadoDeReserva { EstadoDeReservaId = 1, Estado = "Activa" },
                new EstadoDeReserva { EstadoDeReservaId = 2, Estado = "Cancelada" },
                new EstadoDeReserva { EstadoDeReservaId = 3, Estado = "Atendida" }
            );

            //Bloqueos de mesas
            modelBuilder.Entity<BloqueoMesa>().HasData(
                new BloqueoMesa { BloqueoMesaId = 1, MesaId = 2, Fecha = new DateTime(2026, 6, 15), HoraInicio = new DateTime(2026, 6, 15, 8, 0, 0), HoraFin = new DateTime(2026, 6, 15, 22, 0, 0), Detalle = "Mantenimiento de mesa" },
                new BloqueoMesa { BloqueoMesaId = 2, MesaId = 6, Fecha = new DateTime(2026, 6, 16), HoraInicio = new DateTime(2026, 6, 16, 18, 0, 0), HoraFin = new DateTime(2026, 6, 16, 22, 0, 0), Detalle = "Evento privado" },
                new BloqueoMesa { BloqueoMesaId = 3, MesaId = 10, Fecha = new DateTime(2026, 6, 15), HoraInicio = new DateTime(2026, 6, 15, 8, 0, 0), HoraFin = new DateTime(2026, 6, 15, 11, 0, 0), Detalle = "Limpieza profunda" },
                new BloqueoMesa { BloqueoMesaId = 4, MesaId = 3, Fecha = new DateTime(2026, 6, 18), HoraInicio = new DateTime(2026, 6, 18, 12, 0, 0), HoraFin = new DateTime(2026, 6, 18, 15, 0, 0), Detalle = "Reserva especial" },
                new BloqueoMesa { BloqueoMesaId = 5, MesaId = 9, Fecha = new DateTime(2026, 6, 19), HoraInicio = new DateTime(2026, 6, 19, 8, 0, 0), HoraFin = new DateTime(2026, 6, 19, 11, 0, 0), Detalle = "Inspección de zona VIP" }
            );

        }
    }
}
    