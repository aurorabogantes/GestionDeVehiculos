using GestionDeVehiculos.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GestionDeVehiculos.DA
{
    public class RepositorioVehiculoEnMemoria : IRepositorioVehiculo
    {
        private readonly VehiculosDbContext _context;

        public RepositorioVehiculoEnMemoria(VehiculosDbContext context)
        {
            _context = context;
        }

        public async Task<Vehiculo> AddAsync(Vehiculo vehiculo, CancellationToken ct = default)
        {
            _context.Vehiculos.Add(vehiculo);
            await _context.SaveChangesAsync(ct);
            return vehiculo;
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
        {
            var vehiculo = await _context.Vehiculos.FindAsync([id], ct);
            if (vehiculo is null)
                return false;

            _context.Vehiculos.Remove(vehiculo);
            await _context.SaveChangesAsync(ct);
            return true;
        }

        public async Task<Vehiculo?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _context.Vehiculos.FindAsync([id], ct);
        }

        public async Task<IEnumerable<Vehiculo>> GettAllAsync(CancellationToken ct = default)
        {
            return await _context.Vehiculos.ToListAsync(ct);
        }

        public async Task<bool> UpdateAsync(Vehiculo vehiculo, CancellationToken ct = default)
        {
            var existente = await _context.Vehiculos.FindAsync([vehiculo.Id], ct);
            if (existente is null)
                return false;

            _context.Entry(existente).CurrentValues.SetValues(vehiculo);
            await _context.SaveChangesAsync(ct);
            return true;
        }
    }
}

