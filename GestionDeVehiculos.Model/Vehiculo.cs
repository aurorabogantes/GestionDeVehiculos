using System.Text.RegularExpressions;

namespace GestionDeVehiculos.Model
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public Marca Marca { get; set; }
        public int Año { get; set; }
        public string Modelo { get; set; }
        public int DobleTraccion { get; set; }
    }
}
