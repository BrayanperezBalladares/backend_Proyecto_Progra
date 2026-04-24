using ProyectoIProgra2.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ProyectoIProgra2.RestaurantDbContext
{
    public class RestaurantDbTestContext : RestaurantDBContext

    {
        protected override void OnConfiguring(RestaurantDbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("RestaurantDbTest");
        }
        public DbSet<Cliente> Clientes { get; set; }    

        public DbSet<Mesa> Mesas { get; set; }

        public DbSet<Reserva> Reservas { get; set; }

        public DbSet<Zona> Zonas { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<BloqueoMesa> BloqueosMesa { get; set; }

        public DbSet<EstadoDeReserva> EstadosDeReserva { get; set; }

        public DbSet<ListaDeEspera> ListasDeEspera { get; set; }    



    }
}