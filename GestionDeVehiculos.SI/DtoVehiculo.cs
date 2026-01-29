using GestionDeVehiculos.Model;

namespace GestionDeVehiculos.SI.Dto
{
    public record DtoVehiculo(int Id, Marca Marca, int Año, string Modelo, int DobleTraccion);
}