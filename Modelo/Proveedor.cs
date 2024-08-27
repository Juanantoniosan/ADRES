using System;
using System.Collections.Generic;

namespace PruebaAdres.Modelo;

public partial class Proveedor
{
    public int ProveedorId { get; set; }

    public string NombreEntidad { get; set; } = null!;

    public string TipoDocumento { get; set; } = null!;

    public string NumeroDocumento { get; set; } = null!;

    public virtual ICollection<Adquisicione> Adquisiciones { get; set; } = new List<Adquisicione>();
}
