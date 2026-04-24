using ProyectoIProgra2.Servicios;
using ProyectoIProgra2.Servicios.Interfaces;
using ProyectoIProgra2.RestaurantDbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Servicios.AddScoped<RestaurantDbTestContext>();

builder.Servicios.AddScoped<IBloqueoMesaServicio, BloqueoMesaServicio>();

builder.Servicios.AddScoped<IClienteServicio, ClienteServicio>();

builder.Servicios.AddScoped<IEstadoDeReservaServicio, EstadoDeReservaServicio>();

builder.Servicios.AddScoped<IListaDeEsperaServicio, ListaDeEsperaServicio>();

builder.Servicios.AddScoped<IMesaServicio, MesaServicio>();

builder.Servicios.AddScoped<IReservaServicio, ReservaServicio>();

builder.Servicios.AddScoped<ITurnoServicio, TurnoServicio>();

builder.Servicios.AddScoped<IZonaServicio, ZonaServicio>();

builder.Servicios.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Servicios.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
