using Abstracciones.Interfaces.Flujo;
using Abstracciones.Modelos.Servicios.LeccionBosque;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeccionBosqueController : ControllerBase
    {
        private readonly ILeccionBosqueFlujo _leccionBosqueFlujo;

        public LeccionBosqueController(ILeccionBosqueFlujo leccionBosqueFlujo)
        {
            _leccionBosqueFlujo = leccionBosqueFlujo;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodas()
        {
            var resultado = await _leccionBosqueFlujo.ObtenerTodosAsync();
            if (!resultado.Any())
                return NoContent();

            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var entidad = await _leccionBosqueFlujo.ObtenerPorIdAsync(id);
            if (entidad == null)
                return NotFound();

            return Ok(entidad);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] LeccionBosque entidad)
        {
            await _leccionBosqueFlujo.CrearAsync(entidad);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = entidad.Id }, entidad);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] LeccionBosque entidad)
        {
            if (id != entidad.Id)
                return BadRequest();

            await _leccionBosqueFlujo.ActualizarAsync(entidad);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _leccionBosqueFlujo.EliminarAsync(id);
            return NoContent();
        }
    }
}