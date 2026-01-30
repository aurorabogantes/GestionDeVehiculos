using GestionDeVehiculos.BL;
using GestionDeVehiculos.Model;
using Microsoft.AspNetCore.Mvc;

namespace GestionDeVehiculos.SI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiculosController : ControllerBase
    {
        private readonly IServicioVehiculo _servicio;
        
        public VehiculosController(IServicioVehiculo servicio)
        {
            _servicio = servicio;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehiculo>>> GetAll(CancellationToken ct)
        {
            var vehiculos = await _servicio.GetAllAsync(ct);
            return Ok(vehiculos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vehiculo>> GetById(int id, CancellationToken ct)
        {
            var vehiculo = await _servicio.GetByIdAsync(id, ct);
            if (vehiculo is null)
                return NotFound();

            return Ok(vehiculo);
        }

        [HttpPost]
        public async Task<ActionResult<Vehiculo>> Create(Vehiculo vehiculo, CancellationToken ct)
        {
            var creado = await _servicio.CreateAsync(vehiculo, ct);
            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Vehiculo vehiculo, CancellationToken ct)
        {
            if (id != vehiculo.Id)
                return BadRequest();

            var actualizado = await _servicio.UpdateAsync(vehiculo, ct);
            if (!actualizado)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id, CancellationToken ct)
        {
            var eliminado = await _servicio.DeleteAsync(id, ct);
            if(!eliminado)
                return NotFound();

            return NoContent();
        }
    }
}
