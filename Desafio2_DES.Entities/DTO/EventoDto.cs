using System.ComponentModel.DataAnnotations;
using Desafio2_DES.Entities.Attributes;

namespace Desafio2_DES.Entities.DTO
{
    public class EventoDto
    {
        public int CodigoEvento { get; set; }

        [Required(ErrorMessage = "Nombre es requerido")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "El nombre del evento debe de tener entre 5 y 100 caracteres")]
        public string NombreEvento { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha es requerida")]
        [FechaFutura(ErrorMessage = "La fecha del evento debe ser hoy o una fecha futura")]
        public DateTime? FechaEvento { get; set; }

        [StringLength(100, MinimumLength = 5, ErrorMessage = "El lugar del evento debe de tener entre 5 y 100 caracteres")]
        [Required(ErrorMessage = "Lugar es requerido")]
        public string LugarEvento { get; set; } = string.Empty;
    }
}
