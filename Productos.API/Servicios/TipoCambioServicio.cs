using Abstracciones.Interfaces.Servicios;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Servicios
{
    public class TipoCambioServicio : ITipoCambioServicio
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration; 

        public TipoCambioServicio(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task<decimal> ObtenerTipoCambio()
        {
            var urlBase = _configuration["BancoCentralCR:UrlBase"];
            var token = _configuration["BancoCentralCR:BearerToken"];

            string fechaActual = DateTime.Now.ToString("yyyy/MM/dd");

            string url = $"{urlBase}?fechaInicio={fechaActual}&fechaFin={fechaActual}&idioma=ES";

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();

            using var doc = JsonDocument.Parse(content);

            var root = doc.RootElement;

            var tipoCambio =
                root.GetProperty("datos")[0]
                    .GetProperty("indicadores")[0]
                    .GetProperty("series")[0]
                    .GetProperty("valorDatoPorPeriodo")
                    .GetDecimal();

            return tipoCambio;

           
        }
    }
}
