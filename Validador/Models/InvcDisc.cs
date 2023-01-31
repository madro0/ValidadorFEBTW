using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Validador.Models
{
    internal class InvcDisc
    {
        [Required(ErrorMessage = "Error: Debe indicar la Id de la compañía en la etiqueta {0}")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Error: Debe indicar el Número interno de la factura en la etiqueta {0}")]
        public string InvoiceNum { get; set; }

        [Required(ErrorMessage = "Error: Debe indicar un código interno para el descuento global en la etiqueta {0}")]
        public string DiscCode { get; set; }

        [Required(ErrorMessage = "Error: Debe indicar una descripción para el descuento global en la etiqueta {0}")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Error: En la etiqueta {0} debe indicar una la base sobre la cual se calculará el descuento global de la factura")]
        public decimal DiscBaseAmount { get; set; }

        [Required(ErrorMessage ="Error: En la etiqueta {0} debe indicar el valor del descuento global en moneda local (COP)")]
        public decimal DiscAmt { get; set; }

        [Required(ErrorMessage = "Error: En la etiqueta {0} debe indicar el valor del descuento global en la moneda transaccional")]
        public decimal DocDiscAmt { get; set; }

        [Required(ErrorMessage = "Error: Debe indicar una descripción para el código de desceunto global en la etiqueta {0}")]
        public string DiscCodeDescription { get; set; }

        [Required(ErrorMessage = "Error: En la etiqueta {0} debe indicar el porcentaje del descuento global aplicado desceunto si no tiene debe ir en cero (0.00)")]
        public decimal Percentage { get; set; }
    }
}
