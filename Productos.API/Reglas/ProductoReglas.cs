using Abstracciones.Interfaces.Flujo;
using Abstracciones.Interfaces.Servicios;
using System.Security.AccessControl;

namespace Reglas
{
    public class ProductoReglas : IProductoReglas
    {
        private readonly ITipoCambioServicio _tipoCambioServicio;

        public ProductoReglas(ITipoCambioServicio tipoCambioServicio)
        {
            _tipoCambioServicio = tipoCambioServicio;
        }
        public async Task<decimal> CalcularPrecioDolar(decimal Precio)
        {
            var tipoCambio = await _tipoCambioServicio.ObtenerTipoCambio();
            return Precio / tipoCambio; 
        }
    }
}
