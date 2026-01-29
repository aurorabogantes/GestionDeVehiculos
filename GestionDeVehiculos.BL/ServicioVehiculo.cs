using GestionDeVehiculos.DA;
using GestionDeVehiculos.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GestionDeVehiculos.BL
{
    public class ServicioVehiculo : IServicioVehiculo
    {
        private readonly IRepositorioVehiculo _repo;

        public ServicioVehiculo(IRepositorioVehiculo repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<Vehiculo>> GetAllAsync(CancellationToken ct = default)
        {
            return _repo.GettAllAsync(ct);
        }

        public Task<Vehiculo?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return _repo.GetByIdAsync(id, ct);
        }

        public Task<Vehiculo> CreateAsync(Vehiculo vehiculo, CancellationToken ct = default)
        {
            return _repo.AddAsync(vehiculo, ct);
        }

        public Task<bool> UpdateAsync(Vehiculo vehiculo, CancellationToken ct = default)
        {
            return _repo.UpdateAsync(vehiculo, ct);
        }

        public Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            return _repo.DeleteAsync(id, ct);
        }
    }
}
