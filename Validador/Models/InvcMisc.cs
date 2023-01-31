using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Validador.Models
{
    internal class InvcMisc
    {
        [Required(ErrorMessage = "Error: Debe indicar la Id de la compañía en la etiqueta {0}")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Error: Debe indicar el Número interno de la factura en la etiqueta {0}")]
        public string InvoiceNum { get; set; }

        [Required(ErrorMessage = "Error: En la etiqueta {0} Debe indicar el número de línea de referencia para el cargo miscelaneo")]
        public int ? InvoiceLine { get; set; }

        [Required(ErrorMessage = "Error: Debe indicar un código interno para el cargo Míscelaneo en la etiqueta {0}")]
        public string MiscCode { get; set; }

        [Required(ErrorMessage = "Error: Debe indicar una descripción para el cargo miscelaneo en la etiqueta {0}")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Error: En la etiqueta {0} debe indicar el valor del cargo míscelaneo en moneda local (COP)")]
        public decimal ? MiscAmt { get; set; }

        [Required(ErrorMessage = "Error: En la etiqueta {0} debe indicar el valor del cargo míscelaneo en la moneda de la transacción")]
        public decimal ? DocMiscAmt { get; set; }

        [Required(ErrorMessage = "Error: Debe indicar una descripción del código para el cargo míscelaneo en la etiqueta {0}")]
        public string MiscCodeDescription { get; set; }

        [Required(ErrorMessage = "Error: En la etiquete {0} debe incicar el porcentaje del cargo aplicado, si no tienen el valor debe ser cero (0.00)")]
        public decimal ? Percentage { get; set; }

        [Required(ErrorMessage = "Advertencia: En la etiquete {0} debe incicar el valor base del cargo en caso de no estar asociado que el cargo no este asociado a ninguna línea")]
        public decimal ? MiscBaseAmt { get; set; }


    }
}
