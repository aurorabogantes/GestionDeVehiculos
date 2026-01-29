using GestionDeVehiculos.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace GestionDeVehiculos.DA
{
    public class RepositorioVehiculoEnMemoria
    {
        private readonly ConcurrentDictionary<int, Vehiculo> _tienda = new();
        private int _idContador = 0;

        public Task<Vehiculo> AddAsync(Vehiculo vehiculo, CancellationToken ct = default) {
            var id = Interlocked.Increment(ref _idContador);
            vehiculo.Id = id;
            _tienda[id] = vehiculo;
            return Task.FromResult(vehiculo);
        }

        public Task<bool> DeleteAsync(int id, CancellationToken ct  = default) {
            return Task.FromResult(_tienda.TryRemove(id, out _));
        }

        public Task<IEnumerable<Vehiculo>> GetAllAsync(CancellationToken ct = default) {
            return Task.FromResult(_tienda.Values.AsEnumerable());
        }

        public Task<Vehiculo?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            _tienda.TryGetValue(id, out var vehiculo);
            return Task.FromResult(vehiculo);
        }

        public Task<bool> UpdateAsync(Vehiculo vehiculo, CancellationToken ct = default)
        {
            if (!_tienda.ContainsKey(vehiculo.Id)) return Task.FromResult(false);
            _tienda[vehiculo.Id] = vehiculo;
            return Task.FromResult(true);
        }
    }
}
