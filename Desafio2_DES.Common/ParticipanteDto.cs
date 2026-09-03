using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio2_DES.Common;

public class ParticipanteDto
{
    public int IdParticipante { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int IdEvento { get; set; }
}