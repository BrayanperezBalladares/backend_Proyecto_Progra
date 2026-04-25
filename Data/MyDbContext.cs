using Microsoft.EntityFrameworkCore;
using ProyectoProgra2.Entidades;

namespace ProyectoProgra2.Data
{

    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
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