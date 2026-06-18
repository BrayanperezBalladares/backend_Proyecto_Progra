//Program.cs
using ProyectoIProgra2.Data;
using ProyectoIProgra2.Servicios;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<MyAppDbContext>();

builder.Services.AddScoped<IBloqueoMesaServicio, BloqueoMesaServicio>();

builder.Services.AddScoped<IClienteServicio, ClienteServicio>();

builder.Services.AddScoped<IListaDeEsperaServicio, ListaDeEsperaServicio>();

builder.Services.AddScoped<IMesaServicio, MesaServicio>();

builder.Services.AddScoped<IReservaServicio, ReservaServicio>();

builder.Services.AddScoped<ITurnoServicio, TurnoServicio>();

builder.Services.AddScoped<IZonaServicio, ZonaServicio>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", policy =>
        policy
            .WithOrigins(
                "http://localhost:5173",
                "http://127.0.0.1:5173")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("Frontend");

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<MyAppDbContext>();
    dbContext.Database.EnsureCreated();
}

app.Run();
