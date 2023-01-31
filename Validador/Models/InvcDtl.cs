using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validador.Models
{
    internal class InvcDtl
    {
        [Required(ErrorMessage = "Error: Debe indicar la Id de la compañía en la etiqueta {0}")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Error: Debe indicar el Número interno de la factura en la etiqueta {0}")]
        public string InvoiceNum { get; set; }

        [Required(ErrorMessage = "Error: Debe indicar el número de línea facturado en la etiqueta {0}")]
        public int ? InvoiceLine { get; set; }

        [Required(ErrorMessage = "Advertencia: Se recomienda agregar el número de parte en la etiqueta {0}")]
        public string ? PartNum { get; set; }

        [Required(ErrorMessage ="Error: Debe agregar una descripción al ítem facturado {0}" )]
        public string LineDesc { get; set; }

        //[Required(ErrorMessage = "Advertencia: Se recomienda agregar una descripción interna del ítem facturado en la etiqueta {0}")]
        public string PartNumPartDescription { get; set; }

        [Required(ErrorMessage ="Error: Debe agregar la cantidad del producto/servicio vendido {0}" )]
        public decimal ? SellingShipQty { get; set; }

        [Required(ErrorMessage ="Error: Debe agregar la unidad de medida en la etiqueta {0}")]
        public string SalesUM { get; set; }

        [Required(ErrorMessage ="Error: Debe agregar el precio unitario en modena local (COP) en la etiqueta {0}")]
        public decimal ? UnitPrice { get; set; }

        [Required(ErrorMessage ="Error: Debe agregar el precio unitario en la moneda transaccional en la ettiqueta {0}")]
        public decimal ? DocUnitPrice { get; set; }

        [Required(ErrorMessage ="Error: Debe agregar el precio extendido del producto en la moneda local (COP) etiqueta {0}")]
        public decimal ? DocExtPrice { get; set; }

        [Required(ErrorMessage ="Error: Debe agregar el precio extendido del producto/servicio en la moneda trasaccional {0}")]
        public decimal ? DspDocExtPrice { get; set; }

        [Required(ErrorMessage ="Error: debe agregar el procentaje del descuento a nivel de línea en la etiqueta {0}, si no hay descuento el valor debe ser cero (0.00)")]
        public decimal ? DiscountPercent { get; set; }

        [Required(ErrorMessage = "Error: debe agregar el valor de descuento a nivel de línea en la moneda local (COP) en la etiqueta [0], si no hay descuento el valor debe cero (0.00)")]
        public decimal ? Discount { get; set; }

        [Required(ErrorMessage = "Error: debe agregar el valor de descuento a nivel de línea en la moneda trasaccional en la etiqueta [0], si no hay descuento el valor debe cero (0.00)")]
        public decimal ? DocDiscount { get; set; }

        [Required(ErrorMessage = "Error: debe agregar el valor de descuento a nivel de línea en la moneda trasaccional en la etiqueta [0], si no hay descuento el valor debe cero (0.00)")]
        public decimal ? DspDocLessDiscount { get; set; }

        [Required(ErrorMessage = "Error: debe agregar el valor del cargo míscelaneo en la etiqueta [0], si la línea no tienen cargo míscelaneo en valor debe cero (0.00)")]
        public decimal ? DspDocTotalMiscChrg { get; set; }

        [Required(ErrorMessage = "Error: debe agregar el código de la moneda en la que se hace la ransacción en la etiqueta {0}")]
        public string CurrencyCode { get; set; }

    }
}
