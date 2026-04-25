using Microsoft.EntityFrameworkCore;
using ProyectoIProgra2.Entidades;
namespace ProyectoIProgra2.Data
{

    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptionsBuilder options)
        {
            options.UseInMemoryDatabase("MyAppDbContext");
        }
        
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Zona> Zonas { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<EstadoDeReserva> EstadosReserva { get; set; }
        public DbSet<BloqueoMesa> BloqueosMesas { get; set; }
        public DbSet<ListaDeEspera> ListasEspera { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
