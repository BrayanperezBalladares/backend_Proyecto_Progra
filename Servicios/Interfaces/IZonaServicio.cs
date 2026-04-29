using ProyectoIProgra2.Entidades;

public interface IZonaServicio
{
    public List<Zona> ListarZonas();

    public Zona BuscarZonaPorId(int zonaId);

    public List<Mesa> ObtenerMesasDeUnaZona(int zonaId);

    public Zona CrearZona(Zona zona);

    public Zona ActualizarZona(int zonaId, Zona zona);

    public void EliminarZona(int zonaId);
}