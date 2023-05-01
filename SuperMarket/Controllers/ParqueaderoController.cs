using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperMarcket.Data;
using SuperMarket.Data.Model;

namespace SuperMarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParqueaderoController : ControllerBase
    {
        private BaseContext _BaseDatos;

        public ParqueaderoController(BaseContext baseDatos)
        {
            _BaseDatos = baseDatos;
        }

        [HttpGet("GetAllParqueadero")]
        public List<Parqueadero> GetAll()
        {
            return _BaseDatos.Parqueaderos.ToList();
        }

        [HttpPost("CrearParqueadero")]
        public async Task<IActionResult> CrearParqueadero([FromBody] Parqueadero parqueadero)
        {
            if (parqueadero == null)
            {
                return BadRequest();
            }

            // Agregar la nueva fila de parqueadero en la base de datos
            _BaseDatos.Parqueaderos.Add(parqueadero);
            await _BaseDatos.SaveChangesAsync();

            return CreatedAtRoute("GetParqueadero", new { id = parqueadero.Id }, parqueadero);
        }

        [HttpGet("GetParqueadero/{id}", Name = "GetParqueadero")]
        public IActionResult GetById(int id)
        {
            var parqueadero = _BaseDatos.Parqueaderos.FirstOrDefault(p => p.Id == id);

            if (parqueadero == null)
            {
                return NotFound();
            }

            return Ok(parqueadero);
        }

        [HttpPut("ActualizarParqueadero/{id}", Name = "ActualizarParqueadero")]
        public async Task<IActionResult> ActualizarParqueadero(int id, [FromBody] Parqueadero parqueadero)
        {
            var parqueaderoExistente = _BaseDatos.Parqueaderos.FirstOrDefault(p => p.Id == id);

            if (parqueaderoExistente == null)
            {
                return NotFound();
            }

            parqueaderoExistente.Nombre = parqueadero.Nombre;
            parqueaderoExistente.Direccion = parqueadero.Direccion;
            parqueaderoExistente.Capacidad = parqueadero.Capacidad;

            _BaseDatos.Parqueaderos.Update(parqueaderoExistente);
            await _BaseDatos.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("BorrarParqueadero/{id}", Name = "BorrarParqueadero")]
        public async Task<IActionResult> BorrarParqueadero(int id)
        {
            var parqueadero = _BaseDatos.Parqueaderos.FirstOrDefault(p => p.Id == id);

            if (parqueadero == null)
            {
                return NotFound();
            }

            _BaseDatos.Parqueaderos.Remove(parqueadero);
            await _BaseDatos.SaveChangesAsync();

            return NoContent();
        }
    }
}

