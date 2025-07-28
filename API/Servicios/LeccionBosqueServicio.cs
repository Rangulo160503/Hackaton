using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios.Leccion;
using Abstracciones.Modelos.Servicios.LeccionBosque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Servicios
{
    public class LeccionBosqueServicio : ILeccionBosqueServicio
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguracion _configuracion;

        public LeccionBosqueServicio(IHttpClientFactory httpClientFactory, IConfiguracion configuracion)
        {
            _httpClientFactory = httpClientFactory;
            _configuracion = configuracion;
        }

        public async Task<IEnumerable<LeccionBosque>> ObtenerTodosAsync()
        {
            // 1️⃣ Obtener endpoint desde la configuración (opcional)
            var endpoint = _configuracion.ObtenerMetodo("ApiEndPointsLeccionBosque", "GetAllLecciones");

            // 2️⃣ Crear el cliente
            var cliente = _httpClientFactory.CreateClient("ServicioLeccionBosque");
            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // 3️⃣ Realizar la petición
            var respuesta = await cliente.GetAsync(endpoint);
            respuesta.EnsureSuccessStatusCode();

            // 4️⃣ Leer contenido
            var contenido = await respuesta.Content.ReadAsStringAsync();
            var opciones = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var resultado = JsonSerializer.Deserialize<List<LeccionBosque>>(contenido, opciones);

            return resultado ?? new List<LeccionBosque>();
        }

        public Task<LeccionBosque> ObtenerPorIdAsync(int id)
        {
            // De momento no implementado para la demo del mock
            return Task.FromResult<LeccionBosque>(null);
        }

        public Task CrearAsync(LeccionBosque entidad)
        {
            // Simulación: no implementado (no hay POST en el mock)
            return Task.CompletedTask;
        }

        public Task ActualizarAsync(LeccionBosque entidad)
        {
            // Simulación: no implementado
            return Task.CompletedTask;
        }

        public Task EliminarAsync(int id)
        {
            // Simulación: no implementado
            return Task.CompletedTask;
        }
    }
}
