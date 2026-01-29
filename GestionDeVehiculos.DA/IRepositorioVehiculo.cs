using GestionDeVehiculos.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionDeVehiculos.DA
{
    public interface IRepositorioVehiculo
    {
        Task<IEnumerable<Vehiculo>> GettAllAsync(CancellationToken ct = default);
        Task<Vehiculo?> GetByIdAsync(int id, CancellationToken ct  = default);
        Task<Vehiculo> AddAsync(Vehiculo vehiculo, CancellationToken ct = default);
        Task<bool> UpdateAsync(Vehiculo vehiculo, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}
