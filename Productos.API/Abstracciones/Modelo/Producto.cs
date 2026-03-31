using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelo
{
    public class ProductoBase
    {
        [Required(ErrorMessage = "La propiedad  nombre es requerida")]
        [StringLength(40, ErrorMessage = "la propiedad color debe de ser mayo a 3 caracteres y menos de 40", MinimumLength = 3)]

        public string Nombre { get; set; }

        [Required(ErrorMessage = "La propiedad descripcion es requerida")]
        [StringLength(300, ErrorMessage = "la propiedad color debe de ser mayo a 10 caracteres y menos de 40", MinimumLength =10)]

        public string Descripcion { get; set; }
        [Required(ErrorMessage = "La propiedad precio es requerida")]
        
        public decimal Precio { get; set; }
        [Required(ErrorMessage = "La propiedad stock es requerida")]

        public int Stock { get; set; }

        [Required(ErrorMessage = "La propiedad codigo de barras es requerida")]


        public string CodigoBarras { get; set; }
    }

    public class ProductoRequest : ProductoBase
    {
        public Guid IdSubCategoria { get; set; }
    }

    public class ProductoResponse : ProductoBase
    {
        public Guid Id { get; set; }
        public string SubCategoria { get; set; }
        public string Categoria { get; set; }
        public decimal PrecioUSD { get; set; }

    }

    
}
