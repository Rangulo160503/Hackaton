using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Servicios.Leccion;
using Abstracciones.Modelos.Servicios.LeccionBosque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flujo
{
    public class LeccionBosqueFlujo : ILeccionBosqueFlujo
    {
        private readonly ILeccionBosqueServicio _leccionBosqueServicio;

        public LeccionBosqueFlujo(ILeccionBosqueServicio leccionBosqueServicio)
        {
            _leccionBosqueServicio = leccionBosqueServicio;
        }

        public async Task<IEnumerable<LeccionBosque>> ObtenerTodosAsync()
        {
            return await _leccionBosqueServicio.ObtenerTodosAsync();
        }

        public async Task<LeccionBosque> ObtenerPorIdAsync(int id)
        {
            return await _leccionBosqueServicio.ObtenerPorIdAsync(id);
        }

        public async Task CrearAsync(LeccionBosque entidad)
        {
            await _leccionBosqueServicio.CrearAsync(entidad);
        }

        public async Task ActualizarAsync(LeccionBosque entidad)
        {
            await _leccionBosqueServicio.ActualizarAsync(entidad);
        }

        public async Task EliminarAsync(int id)
        {
            await _leccionBosqueServicio.EliminarAsync(id);
        }
    }
}
