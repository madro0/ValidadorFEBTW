using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validador.Models
{
    internal class SalesTrc
    {
        [Required(ErrorMessage = "Error: Debe indicar la Id de la compañía en la etiqueta {0}")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Error: Debe indicar un código interno para la tasa del impuesto en la etiqueta {0}")]
        public string RateCode { get; set; }

        [Required(ErrorMessage ="Error: Debe indicar un código interno para el tipo de impuesto en la etiqueta {0}")]
        public string TaxCode { get; set; }

        [Required(ErrorMessage = "Error: Debe indicar una descripción para la tasa del impuesto en la etiqueta {0}")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Error: Debe indicar el id DIAN para el tipo del tributo en la etiqueta {0}")]
        public string IdImpDIAN_c { get; set; }

        public string TotalValueTaxRenta { get; set; }
    }
}
