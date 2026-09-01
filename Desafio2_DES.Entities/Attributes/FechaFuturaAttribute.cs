using System.ComponentModel.DataAnnotations;

namespace Desafio2_DES.Entities.Attributes
{
    public class FechaFuturaAttribute : ValidationAttribute
    {
        public FechaFuturaAttribute()
        {
            ErrorMessage = "La fecha del evento debe ser hoy o una fecha posterior.";
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            // Accept DateTime (nullable handled by previous check)
            if (value is DateTime fecha)
            {
                var hoy = DateTime.Today.Date;

                if (fecha.Date < hoy)
                {
                    return new ValidationResult(ErrorMessage);
                }

                return ValidationResult.Success;
            }

            return new ValidationResult("El formato de fecha proporcionado no es válido.");
        }
    }
}