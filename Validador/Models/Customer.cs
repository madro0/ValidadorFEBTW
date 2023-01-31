using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Validador.Models
{
    internal class Customer
    {
        [Required(ErrorMessage = "Error: Debe indicar la Id de la compañía en la etiqueta {0}")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Error: Debe indicar el número de indentificación del cliente, sin digito de verificación en la etiqueta {0}")]
        public string CustID { get; set; }

        [Required(ErrorMessage = "Error: Debe indicar el número de indentificación del cliente, sin digito de verificación en la etiqueta {0}")]
        public string CustNum { get; set; }

        [Required(ErrorMessage = "Error: Debe indicar el número de indentificación del cliente, sin digito de verificación en la etiqueta {0}")]
        public string ResaleID { get; set; }

        [Required(ErrorMessage = "Error: Debe indicar el nombre o razón social del adquiriente en la etiqueta {0}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Error: Debe indicar la dirección del adquiriente en la etiqueta {0}")]
        public string Address1 { get; set; }

        [Required(ErrorMessage ="Error: Debe indicar la dirección electrónica del adquiriente en la etiqueta {0}")]
        [DataType(DataType.EmailAddress, ErrorMessage ="Error: El campo {0} debe contener una dirección de email valida")]
        public string EMailAddress { get; set; }

        [Required(ErrorMessage ="Error: Debe inficar un número de teléfono de contacto del adquiriente en la etiqueta {0}")]
        public string PhoneNum { get; set; }

        [Required(ErrorMessage ="Error: En la etiquete {0} debe indicar el código de la moneda en la que se realizó la trasacción")]
        public string CurrencyCode { get; set; }

        [Required(ErrorMessage = "Error: Debe indicar el nombre del país de residencia del cliente en la etiqueta {0}")]
        public string ? Country { get; set; }

        [Required(ErrorMessage = "Error: debe indicar el tipo de régimen del adquiriente en la etiqueta {0}")]
        public string RegimeType_c { get; set; }

        [Required(ErrorMessage ="Error: Debe indicar al resposabilidad fiscal del adquiriente en la etiqueta {0}")]
        public string FiscalResposability_c { get; set; }

        [Required(ErrorMessage ="Error: Debe indicar el nombre del departamento de residencia del cliente en la etiqueta {0}")]
        public string ? State { get; set; }

        [Required(ErrorMessage ="Error: Debe indicar el código de departamenteo de residencia del cliente en la etiqueta {0}")]
        public string StateNum { get; set; }

        [Required(ErrorMessage ="Error: Debe indicar el nombre de la ciudad o municipio de residencia del cliente en la etiqueta {0}")]
        public string City { get; set; }

        [Required(ErrorMessage = "Error: Debe indicar el código de la ciudad o municipio de residencia del cliente en la etiqueta {0}")]
        public string CityNum { get; set; }
    }

}
