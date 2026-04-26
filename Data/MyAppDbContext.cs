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
        
    }
}
