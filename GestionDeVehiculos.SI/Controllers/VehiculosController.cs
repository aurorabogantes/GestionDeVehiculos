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

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Vehiculo>> GetById(int id, CancellationToken ct)
        {
            if (id <= 0)
                return BadRequest("El ID debe ser mayor que 0");

            var vehiculo = await _servicio.GetByIdAsync(id, ct);
            if (vehiculo is null)
                return NotFound($"No se encontró el vehículo con ID {id}");

            return Ok(vehiculo);
        }

        [HttpPost]
        public async Task<ActionResult<Vehiculo>> Create([FromBody] Vehiculo vehiculo, CancellationToken ct)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var creado = await _servicio.CreateAsync(vehiculo, ct);
            return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] Vehiculo vehiculo, CancellationToken ct)
        {
            if (id <= 0)
                return BadRequest("El ID debe ser mayor que 0");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != vehiculo.Id)
                return BadRequest("El ID de la ruta no coincide con el ID del vehículo");

            var actualizado = await _servicio.UpdateAsync(vehiculo, ct);
            if (!actualizado)
                return NotFound($"No se encontró el vehículo con ID {id}");

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id, CancellationToken ct)
        {
            if (id <= 0)
                return BadRequest("El ID debe ser mayor que 0");

            var eliminado = await _servicio.DeleteAsync(id, ct);
            if(!eliminado)
                return NotFound($"No se encontró el vehículo con ID {id}");

            return NoContent();
        }
    }
}

