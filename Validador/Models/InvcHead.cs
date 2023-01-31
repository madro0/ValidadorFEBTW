using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validador.Helpers;

namespace Validador.Models
{
    internal class InvcHead: ValidationAttribute
    {
        [Required(ErrorMessage = "Error: Debe indicar la Id de la compañía en la etiqueta {0}")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Error: Debe indicar el tipo del documento (InvoiceType, CreditNoteType, DebitNoterType) en la etiqueta {0}")]
        public string InvoiceType { get; set; }

        [Required(ErrorMessage = "Error: Debe indicar el Número interno de la factura en la etiqueta {0}")]
        public string InvoiceNum { get; set; }

        [Required(ErrorMessage = "Error: Debe asignar un Número legal para la factura, este debe estar en la etiqueta {0}")]
        public string LegalNumber { get; set; }

        //[Required(ErrorMessage ="Advertencia: Debería indicar el documento de referencia en la etiqueta {0}")]
        public string ? InvoiceRef { get; set; }

        //[Required(ErrorMessage ="Advertencia: Debería agregar el CUID del documento de referencia en la etiqueta {0}")]
        public string ? InvoiceRefCufe { get; set; }

        //[Required(ErrorMessage ="Advertencia: Debería agregar la fecha de emisión del documento de referencia en la etiqueta {0}")]
        public string ? InvoiceRefDate { get; set; }

        //[Required(ErrorMessage ="Advertencia: Debería indicar el nit del cliente sin dígito de verificación en la etiqueta {0}")]
        public string ? CustNum { get; set; }

        //[Required(ErrorMessage ="Advertencia: Debería indicar el nombre de la persona de contacto o del adqutiriente en la etiqueta {0}")]
        public string ? ContactName { get; set; }

        //[Required(ErrorMessage ="Advertencia: Debería indicar razón social del adqutiriente en la etiqueta {0}")]
        public string ? CustomerName { get; set; }

        [Required(ErrorMessage = "Error: Debe indicar la fecha de emisión del documento electrónico en la etiqueta {0}")]
        //[Helpers.DateValidation]
        public DateTime ? InvoiceDate { get; set; }

        [Required(ErrorMessage ="Advertencia: Deberia indicar la fecha de vencimiento de la factura en la etiqueta {0}")]
        //[Helpers.DateValidation]
        public DateTime ? DueDate { get; set; }

        [Required(ErrorMessage = "Error: Debe indicar el valor total del subtotal en la etiqueta {0}")]
        [RegularExpression(@"^[0-9]+(\.[0-9]{1,6})$", ErrorMessage = "Error: {0} El subtotal debe tener de 1 a 6 decimales.")]
        public decimal ? DspDocSubTotal { get; set; }

        [Required(ErrorMessage = "Error: Debe indicar el valor total de los impuestos en la etiqueta {0}, si no tiene impuestos el valor debe ser cero (0.00) ")]
        [RegularExpression(@"^[0-9]+(\.[0-9]{1,6})$", ErrorMessage = "Error: {0} El valor total de los impuestos debe tener de 1 a 6 decimales.")]
        public decimal ? DocTaxAmt { get; set; }

        [Required(ErrorMessage = "Error: Debe indicar el valor total de las retenciones en la etiqueta {0}, si no tiene retenciones el valor debe ser cero (0.00) ")]
        [RegularExpression(@"^[0-9]+(\.[0-9]{1,6})$", ErrorMessage = "Error: {0} El valor total de las retenciones debe tener de 1 a 6 decimales.")]
        public decimal ? DocWHTaxAmt { get; set; }

        [Required(ErrorMessage = "Error: Debe indicar el valor total de la factura en la etiqueta {0}, si no tiene retenciones el valor debe ser cero (0.00) ")]
        [RegularExpression(@"^[0-9]+(\.[0-9]{1,6})$", ErrorMessage = "Error: {0} El valor total de la factura debe tener de 1 a 6 decimales.")]
        public decimal ? DspDocInvoiceAmt { get; set; }

        [Required(ErrorMessage = "Advertencia: Puede incluir una comentario en la etiquetea {0}, si no tiene ninguno debe dejar la etiqueta en blanco")]
        public string InvoiceComment { get; set; }

        //[Required(ErrorMessage = "Advertencia: Puede incluir la descripción (Nombre) de la moneda en la cual se hace la trasacción en la etiquetea {0}")]
        public string ? CurrencyCodeCurrencyID { get; set; }


        [Required(ErrorMessage = "Error: En la etiquetea {0} debe incluir el código de la moneda en la cual se hace la trasacción ")]
        public string CurrencyCode { get; set; }

        //[Required(ErrorMessage = "Advertencia: Puede incluir el Nro de orden de compra en la etiquetea {0}")]
        public string ? PONum { get; set; }

        //[Required(ErrorMessage = "Advertencia: Puede incluir el Nro de orden de venta en la etiquetea {0}")]
        public string ? OrderNum { get; set; }

        [Required(ErrorMessage = "Error: Debe incluir el descuentno global de la factura en la etiqueta {0}, si no hay descuento global el valor debe ser cero (0.00)")]
        [RegularExpression(@"^[0-9]+(\.[0-9]{1,6})$", ErrorMessage = "Error: {0} El valor del descuento global debe tener de 1 a 6 decimales, si no hay descuento global el valor debe ser cero (0.00)")]
        public decimal ? Discount { get; set; }

        [Required(ErrorMessage ="Error: Debe incluir la forma de pago (1 = contado; 2 = crédito) en la etiqueta {0}")]
        public string PaymentMeansID_c { get; set; }

        [Required(ErrorMessage ="Error: Debe incluir la descripción de la forma de pago (crédito, contado) en la etiqueta {0}")]
        public string PaymentMeansDescription { get; set; }

        [Required(ErrorMessage ="Error: Debe incluir el código del medio de pago en la etiqueta {0}")]
        public string PaymentMeansCode_c { get; set; }

        [Required(ErrorMessage ="Error: Debe incluir los días de plazo para el pago de la factura en la etiqueta {0}")]
        [Range(1, int.MaxValue, ErrorMessage = "Error: debe incluir un número enero valido en la etiqueta {0} para indicar los días de plazo para el pago de la factura")]
        public int PaymentDurationMeasure { get; set; }

        [Required(ErrorMessage ="Error: Debe incluir la fecha límite de pago de la factura en la etiqueta {0}")]
        public DateTime PaymentDueDate { get; set; }

        [Required(ErrorMessage = "Advertencia: debe incluir el valor de la tasa de cambio en la etiquetea {0}")]
        public decimal ? CalculationRate_c { get; set; }

        //[Required(ErrorMessage = "Advertencia: en la etiqueta {0} bebe incluir la fecha en la cual se realizó la transacción en moneda internacional")]
        public DateTime ? DateCalculationRate_c { get; set; }

        public string ? ZipFileBase64_c { get; set; }



        

    }
}
