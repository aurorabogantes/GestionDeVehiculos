using GestionDeVehiculos.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionDeVehiculos.BL
{
    internal interface IServicioVehiculo
    {
        Task<IEnumerable<Vehiculo>> GetAllAsync(CancellationToken ct = default);
        Task<Vehiculo?> GetByIdAsync(int id, CancellationToken ct = default);
        Task<Vehiculo> CreateAsync(Vehiculo vehiculo, CancellationToken ct = default);
        Task<bool> UpdateAsync(Vehiculo vehiculo, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}
