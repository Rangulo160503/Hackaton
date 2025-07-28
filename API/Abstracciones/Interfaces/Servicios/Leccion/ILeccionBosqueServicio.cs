using Abstracciones.Modelos.Servicios.LeccionBosque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Interfaces.Servicios.Leccion
{
    public interface ILeccionBosqueServicio
    {
        Task<IEnumerable<LeccionBosque>> ObtenerTodosAsync();
        Task<LeccionBosque> ObtenerPorIdAsync(int id);
        Task CrearAsync(LeccionBosque entidad);
        Task ActualizarAsync(LeccionBosque entidad);
        Task EliminarAsync(int id);
    }
}
