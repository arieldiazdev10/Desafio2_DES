using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Desafio2_DES.Common;

public class CreateOrganizadorDto
{
    [Required(ErrorMessage = "El nombre es obligatorio")]
    [MinLength(3), MaxLength(50)]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "El cargo es obligatorio")]
    [MinLength(3), MaxLength(50)]
    public string Cargo { get; set; } = string.Empty;

    [Required(ErrorMessage = "El evento asociado es obligatorio")]
    public int IdEvento { get; set; }
}
