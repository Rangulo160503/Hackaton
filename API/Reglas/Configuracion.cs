using Abstracciones.Interfaces.Reglas;
using Abstracciones.Interfaces.Servicios;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Reglas
{
    public class Configuracion : IConfiguracion
    {
        private readonly IConfiguration _configuration;

        public Configuracion(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ObtenerMetodo(string seccion, string nombre)
        {
            string? urlBase = ObtenerUrlBase(seccion);
            var metodo = _configuration.GetSection(seccion)
                .Get<APIEndPoint>()?.Metodos
                .FirstOrDefault(m => m.Nombre == nombre)?.Valor;

            if (string.IsNullOrEmpty(urlBase) || string.IsNullOrEmpty(metodo))
                throw new Exception($"No se encontró la configuración para {seccion}:{nombre}");

            return $"{urlBase}/{metodo}";
        }

        public string ObtenerValor(string llave)
        {
            return _configuration[llave] ?? throw new Exception($"No se encontró la llave de configuración: {llave}");
        }

        private string? ObtenerUrlBase(string seccion)
        {
            return _configuration.GetSection(seccion).Get<APIEndPoint>()?.UrlBase;
        }
    }
}
