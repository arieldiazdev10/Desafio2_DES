using System.ComponentModel.DataAnnotations;

namespace Desafio2_DES.Entities.Models
{
    public class Evento
    {
        [Key]
        public int IdEvento { get; set; }

        public required string Nombre { get; set; }

        public DateTime? Fecha { get; set; }

        public required string Lugar { get; set; }
    }
}
