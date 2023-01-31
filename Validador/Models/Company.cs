using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Validador.Models
{
    internal class Company
    {


        //[Required(ErrorMessage ="Advertencia: Debería indicar la Id de la compañía en la etiqueta Company")]
        //public string ? Company { get; set; }

        [Required(ErrorMessage = "Error: Debe indicar el número de identificación de la compañía en la etiqueta StateTaxID")]
        public string StateTaxID { get; set; }

        [Required(ErrorMessage = "Error: Debe indicar la razón social de la compañia en la etiqueta Name")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Error: Debe inficar el tipo de regimen de la compañía en la etiqueta {0}")]
        public string RegimeType_c { get; set; }

        [Required(ErrorMessage ="Error: Debe indicar la responsabilidad fiscal de la compañia en la etiqueta {0}")]
        public string FiscalResposability_c { get; set; }

        [Required(ErrorMessage ="Error: En la etiqueta {0} debe inficar el tipo de docuemnto (10: Factura electrónica, 20: Nota crédito, 22: Nota crédito sin referencia a FE, 30: Nota débito, 32: Nota débito sin referencia a factura)")]
        public string OperationType_c { get; set; }

        [Required(ErrorMessage ="Error: En la etiqueta {0} debe informar el tipo de persona es la compañía (Personal Juridica: 1; Persona natual: 2)")]
        public string CompanyType_c { get; set; }

        [Required(ErrorMessage ="Error: Debe indicar el nombre del estado o departamente de residencia de la compañía en la etiqueta {0}")]
        public string State { get; set; }

        [Required(ErrorMessage = "Error: Debe indicar el código del estado o departamente de residencia de la compañía en la etiqueta {0}")]
        public string StateNum { get; set; }

        [Required(ErrorMessage ="Error: Debe indicar el nombre de la ciudad o municipio de residencia de la compañia{0}")]
        public string City { get; set; }

        [Required(ErrorMessage ="Error: Debe indicar el código re la ciudad o municipio de residencia de la compañia em ña etiqueta {0}")]
        public string CityNum { get; set; }

        [Required(ErrorMessage ="Error: Debe indicar el número de idenficación de la compañia en la etiqueta {0}")]
        public string IdentificationType { get; set; }

        [Required(ErrorMessage ="Error: Debe indicar la dirección  de residencia de la compañia en la etiqueta {0}")]
        public string Address1 { get; set; }

        [Required(ErrorMessage ="Error: Debe indicar el nombre del país de residencia de la compañia enen la etiqueta {0}")]
        public string Country   { get; set; }

        [Required(ErrorMessage = "Error: Debe incluir el número de telefóno de la compañía en la etiqueta {0}")]
        [MinLength(6, ErrorMessage ="Error: El número de telefóno de la compañia debe tener al menos 6 dígitos en la etiqueta {0}")]
        public string PhoneNum { get; set; }

        [Required(ErrorMessage ="Error: debe informar una dirección de correo electrónico de contacto en la etiqueta {0}")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Error: El campo {0} debe contener una dirección de email valida")]
        public string Email { get; set; }




    }
}
