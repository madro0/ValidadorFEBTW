using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validador.Models
{
    internal class InvcTax
    {
        [Required(ErrorMessage = "Error: Debe indicar la Id de la compañía en la etiqueta {0}")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Error: Debe indicar el Número interno de la factura en la etiqueta {0}")]
        public string InvoiceNum { get; set; }

        [Required(ErrorMessage = "Error: Debe indicar el número de línea facturado en la etiqueta {0}")]
        public int ? InvoiceLine { get; set; }

        [Required(ErrorMessage = "Error: Debe indicar el código de la moneda en la que se hace la tansacción en la etiqueta {0}")]
        public string CurrencyCode { get; set; }

        [Required(ErrorMessage = "Error: Debe indicar código interno de la tasa del impuesto en la etiqueta {0}")]
        public string RateCode { get; set; }

        [Required(ErrorMessage = "Error: Debe indicar el monto sobre el cual se aplicara el impuesto = precio extendido de la línea (DspDocExtPrice) en la etiequeta {0}")]
        public decimal ? DocTaxableAmt { get; set; }

        [Required(ErrorMessage ="Error: Debe indicar el valor del impuesto en la moneda local (COP) en la etiqueta {0}")]
        public decimal ? TaxAmt { get; set; }

        [Required(ErrorMessage ="Error: Debe indicar el valor del impuesto en la moneda trasaccional en la etiqueta {0}")]
        public decimal ? DocTaxAmt { get; set; }

        [Required(ErrorMessage ="Debe inficar el porcentaje del impuesto aplicado en la etiqueta {0}")]
        public decimal ? Percent { get; set; }

        [Required(ErrorMessage ="Debe indicar si el tributo es una retención en la etiqueta {0}")]
        public bool ? WithholdingTax_c { get; set; }

        public decimal ? BaseUnitMeasure_c { get; set; }
        
        public decimal ? PerUnitAmount_c { get; set; }

        public List<SalesTrc> ? salesTrcs { get; set; }
    }

}
