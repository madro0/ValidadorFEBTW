using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Validador.Models
{
    internal class COOneTime
    {
        [Required(ErrorMessage = "Error: Debe indicar la Id de la compañía en la etiqueta {0}")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Error: Debe indicar el código de identificación del adquiriente en la etiqueta {0}")]
        public string IdentificationType { get; set; }

        [Required(ErrorMessage ="Error: Debe indicar el número de identificación del adquiriente en la etiquete {0}")]
        public string COOneTimeID { get; set; }

        [Required(ErrorMessage ="Error: Debe inficar el nombre o razón social del adquiriente en la etiqueta {0}")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage ="Error: Debe indicar el código de identificación del pais de residencia del cliente en la etiqueta {0}")]
        public string CountryCode { get; set; }
    }
}
