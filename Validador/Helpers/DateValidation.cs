using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Validador.Helpers
{
    internal class DateValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Console.WriteLine("dasf");
            if (value != null)
            {
                if (value is DateTime)
                {
                    DateTime date = (DateTime)value;
                    if (date == default(DateTime))
                    {
                        return new ValidationResult($"Error: debe agregar una fecha valida en la etiqueta {validationContext.MemberName}");
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}
