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
                new Zona { ZonaId = 3, Seccion = "Jardín" },
                new Zona { ZonaId = 4, Seccion = "VIP" }
    );
            // Mesas del restaurante
            modelBuilder.Entity<Mesa>().HasData(
        // Interior (3 mesas)
                new Mesa { MesaId = 1, Capacidad = 4, ZonaId = 1 },
                new Mesa { MesaId = 2, Capacidad = 2, ZonaId = 1 },
                new Mesa { MesaId = 3, Capacidad = 6, ZonaId = 1 },

        // Terraza (3 mesas)
                new Mesa { MesaId = 4, Capacidad = 4, ZonaId = 2 },
                new Mesa { MesaId = 5, Capacidad = 2, ZonaId = 2 },
                new Mesa { MesaId = 6, Capacidad = 8, ZonaId = 2 },

        // Jardín (2 mesas)
                new Mesa { MesaId = 7, Capacidad = 4, ZonaId = 3 },
                new Mesa { MesaId = 8, Capacidad = 6, ZonaId = 3 },

        // VIP (2 mesas)
                new Mesa { MesaId = 9, Capacidad = 4, ZonaId = 4 },
                new Mesa { MesaId = 10, Capacidad = 8, ZonaId = 4 }
    );

            // TURNOS DEL RESTAURANTE
            modelBuilder.Entity<Turno>().HasData(
                new Turno { TurnoId = 1, HoraInicio = 8, HoraFin = 11 }, // Desayuno
                new Turno { TurnoId = 2, HoraInicio = 12, HoraFin = 15 }, // Almuerzo
                new Turno { TurnoId = 3, HoraInicio = 18, HoraFin = 22 }  // Cena
            );


            // Clientes de ejemplo
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente { ClienteId = 1, Ced = 101110111, Nombre = "Juan", Apellidos = "Pérez López", Tel = 88881111, Email = "juan@email.com" },
                new Cliente { ClienteId = 2, Ced = 202220222, Nombre = "María", Apellidos = "González Mora", Tel = 88882222, Email = "maria@email.com" },
                new Cliente { ClienteId = 3, Ced = 303330333, Nombre = "Carlos", Apellidos = "Rodríguez Soto", Tel = 88883333, Email = "carlos@email.com" },
                new Cliente { ClienteId = 4, Ced = 404440444, Nombre = "Ana", Apellidos = "Martínez Cruz", Tel = 88884444, Email = "ana@email.com" },
                new Cliente { ClienteId = 5, Ced = 505550555, Nombre = "Luis", Apellidos = "Hernández Vega", Tel = 88885555, Email = "luis@email.com" },
                new Cliente { ClienteId = 6, Ced = 606660666, Nombre = "Sofía", Apellidos = "Jiménez Rojas", Tel = 88886666, Email = "sofia@email.com" },
                new Cliente { ClienteId = 7, Ced = 707770777, Nombre = "Diego", Apellidos = "Ramírez Vargas", Tel = 88887777, Email = "diego@email.com" },
                new Cliente { ClienteId = 8, Ced = 808880888, Nombre = "Valeria", Apellidos = "Castro Núñez", Tel = 88888888, Email = "valeria@email.com" },
                new Cliente { ClienteId = 9, Ced = 909990999, Nombre = "Andrés", Apellidos = "Mora Solano", Tel = 88889999, Email = "andres@email.com" },
                new Cliente { ClienteId = 10, Ced = 111111110, Nombre = "Camila", Apellidos = "Soto Quesada", Tel = 88880000, Email = "camila@email.com" },
                new Cliente { ClienteId = 11, Ced = 121212121, Nombre = "Roberto", Apellidos = "Vega Brenes", Tel = 87771111, Email = "roberto@email.com" },
                new Cliente { ClienteId = 12, Ced = 131313131, Nombre = "Lucía", Apellidos = "Brenes Arias", Tel = 87772222, Email = "lucia@email.com" },
                new Cliente { ClienteId = 13, Ced = 141414141, Nombre = "Miguel", Apellidos = "Arias Campos", Tel = 87773333, Email = "miguel@email.com" },
                new Cliente { ClienteId = 14, Ced = 151515151, Nombre = "Isabella", Apellidos = "Campos Herrera", Tel = 87774444, Email = "isabella@email.com" },
                new Cliente { ClienteId = 15, Ced = 161616161, Nombre = "Fernando", Apellidos = "Herrera Delgado", Tel = 87775555, Email = "fernando@email.com" }
    );


            // Estados posibles de una reserva
            modelBuilder.Entity<EstadoDeReserva>().HasData(
                new EstadoDeReserva { EstadoDeReservaId = 1, Estado = "Activa" },
                new EstadoDeReserva { EstadoDeReservaId = 2, Estado = "Cancelada" },
                new EstadoDeReserva { EstadoDeReservaId = 3, Estado = "Atendida" }
    );

            // Turnos del restaurante
            modelBuilder.Entity<Turno>().HasData(

                new Turno { TurnoId = 1, HoraInicio = 8, HoraFin = 11 },//Desayuno
                new Turno { TurnoId = 2, HoraInicio = 12, HoraFin = 15 },//Almuerzo
                new Turno { TurnoId = 3, HoraInicio = 18, HoraFin = 22 }//Cena
            );

            //Bloqueos de mesas de ejemplo

            modelBuilder.Entity<BloqueoMesa>().HasData(
            // Mesa 2 en mantenimiento
            new BloqueoMesa
        {
            BloqueoMesaId = 1,
            MesaId = 2,
            Fecha = new DateTime(2025, 6, 15),
            HoraInicio = new DateTime(2025, 6, 15, 8, 0, 0),
            HoraFin = new DateTime(2025, 6, 15, 22, 0, 0),
            Detalle = "Mantenimiento de mesa"
        },
            // Mesa 6 bloqueada por evento privado en Terraza
            new BloqueoMesa
        {
            BloqueoMesaId = 2,
            MesaId = 6,
            Fecha = new DateTime(2025, 6, 16),
            HoraInicio = new DateTime(2025, 6, 16, 18, 0, 0),
            HoraFin = new DateTime(2025, 6, 16, 22, 0, 0),
            Detalle = "Evento privado"
        },
            // Mesa 10 VIP bloqueada por limpieza
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

            modelBuilder.Entity<BloqueoMesa>().HasData(
        // Mesa 2 en mantenimiento
        new BloqueoMesa
        {
            BloqueoMesaId = 1, MesaId = 2,
            Fecha = new DateTime(2025, 6, 15),
            HoraInicio = new DateTime(2025, 6, 15, 8, 0, 0),
            HoraFin = new DateTime(2025, 6, 15, 22, 0, 0),
            Detalle = "Mantenimiento de mesa"
        },
        // Mesa 6 bloqueada por evento privado en Terraza
        new BloqueoMesa
        {
            BloqueoMesaId = 2, MesaId = 6,
            Fecha = new DateTime(2025, 6, 16),
            HoraInicio = new DateTime(2025, 6, 16, 18, 0, 0),
            HoraFin = new DateTime(2025, 6, 16, 22, 0, 0),
            Detalle = "Evento privado"
        },
        // Mesa 10 VIP bloqueada por limpieza
        new BloqueoMesa
        {
            BloqueoMesaId = 3, MesaId = 10,
            Fecha = new DateTime(2025, 6, 15),
            HoraInicio = new DateTime(2025, 6, 15, 8, 0, 0),
            HoraFin = new DateTime(2025, 6, 15, 11, 0, 0),
            Detalle = "Limpieza profunda"
        }
    );

            // Reaservas de ejemplo
            modelBuilder.Entity<Reserva>().HasData(
        // Reserva Activa — Almuerzo Interior
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
        // Reserva Activa — Cena Terraza
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
        },
        // Reserva Activa — Desayuno VIP
            new Reserva
        {
                ReservaId = 3,
                ClienteId = 3,
                MesaId = 9,
                TurnoId = 1,
                EstadoDeReservaId = 1,
                CantidaPersonas = 4,
                Fecha = new DateTime(2025, 6, 16),
                HoraInicio = new DateTime(2025, 6, 16, 8, 0, 0),
                HoraFin = new DateTime(2025, 6, 16, 11, 0, 0)
        },
        // Reserva Cancelada — Almuerzo Jardín
            new Reserva
        {
                ReservaId = 4,
                ClienteId = 4,
                MesaId = 7,
                TurnoId = 2,
                EstadoDeReservaId = 2,
                CantidaPersonas = 2,
                Fecha = new DateTime(2025, 6, 14),
                HoraInicio = new DateTime(2025, 6, 14, 12, 0, 0),
                HoraFin = new DateTime(2025, 6, 14, 15, 0, 0)
        },


        // Reserva Atendida — Cena Interior
            new Reserva
        {
                ReservaId = 5,
                ClienteId = 5,
                MesaId = 3,
                TurnoId = 3,
                EstadoDeReservaId = 3,
                CantidaPersonas = 5,
                Fecha = new DateTime(2025, 6, 13),
                HoraInicio = new DateTime(2025, 6, 13, 18, 0, 0),
                HoraFin = new DateTime(2025, 6, 13, 22, 0, 0)
        }
    );

            //ListaDeEspera 
            modelBuilder.Entity<ListaDeEspera>().HasData(
                    // Cliente esperando mesa para almuerzo
                    new ListaDeEspera
                    {
                        ListaDeEsperaId = 1,
                        ClienteId = 6,
                        TurnoId = 2,
                        CantidadPersonas = 4,
                        HoraSolicitud = new DateTime(2025, 6, 15, 11, 30, 0)
                    },
                    // Cliente esperando mesa para cena
                    new ListaDeEspera
                    {
                        ListaDeEsperaId = 2,
                        ClienteId = 7,
                        TurnoId = 3,
                        CantidadPersonas = 2,
                        HoraSolicitud = new DateTime(2025, 6, 15, 17, 0, 0)
                    },
                    // Cliente esperando mesa para desayuno
                    new ListaDeEspera
                    {
                        ListaDeEsperaId = 3,
                        ClienteId = 8,
                        TurnoId = 1,
                        CantidadPersonas = 3,
                        HoraSolicitud = new DateTime(2025, 6, 16, 7, 45, 0)
                    }
                );
        }



    }

    }
}