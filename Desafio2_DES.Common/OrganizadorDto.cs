using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio2_DES.Common;

public class OrganizadorDto
{
    public int IdOrganizador { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Cargo { get; set; } = string.Empty;
    public int IdEvento { get; set; }
}