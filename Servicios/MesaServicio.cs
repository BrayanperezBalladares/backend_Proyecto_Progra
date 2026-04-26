using ProyectoIProgra2.Data;
using ProyectoIProgra2.Entidades;

namespace ProyectoIProgra2.Servicios
{
    public class MesaServicio : IMesaServicio
    {
        private readonly MyAppDbContext _MyAppDbContext;
        public MesaServicio(MyAppDbContext myAppDbContext)
        {
            _MyAppDbContext = myAppDbContext;
        }
        public Mesa ActualizarMesa(int mesaId, Mesa mesa)
        {
            var result = _MyAppDbContext.Mesas.Find(mesaId);
            result.MesaId = mesa.MesaId;
            _MyAppDbContext.Mesas.Update(result);
            _MyAppDbContext.SaveChanges();
            return result;
        }

        public Mesa AsignarReservaAMesa(int mesaId, int reservaId)
        {
            throw new NotImplementedException();
        }

        public Mesa BuscarMesaPorNumero(int numero)
        {
            var result = _MyAppDbContext.Mesas.Find(numero);
            return result;
        }

        public bool ComprobarDisponibilidadMesa(int mesaId, DateTime inicio, DateTime fin)
        {
            throw new NotImplementedException();
        }

        public Mesa CrearMesa(Mesa mesa)
        {
            _MyAppDbContext.Mesas.Add(mesa);
            _MyAppDbContext.SaveChanges();
            return mesa;
        }

        public void EliminarMesa(int mesaId)
        {
            var result = _MyAppDbContext.Mesas.Find(mesaId);
            _MyAppDbContext.Mesas.Remove(result);
            _MyAppDbContext.SaveChanges();
        }

        public List<Mesa> ListarMesas()
        {
            return _MyAppDbContext.Mesas.ToList();
        }

        public List<Mesa> ObtenerMesaPorCapacidad(int capacidad)
        {
            throw new NotImplementedException();
        }

        public List<Mesa> ObtenerMesaPorZona(int zonaId)
        {
            throw new NotImplementedException();
        }

        public List<Mesa> ObtenerMesasDisponibles(DateTime inicio, DateTime fin, int capacidad)
        {
            throw new NotImplementedException();
        }
    }
}
