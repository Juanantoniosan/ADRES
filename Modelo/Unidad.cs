using System;
using System.Collections.Generic;

namespace PruebaAdres.Modelo;

public partial class Unidad
{
    public int UnidadId { get; set; }

    public string NombreUnidad { get; set; } = null!;

    public virtual ICollection<Adquisicione> Adquisiciones { get; set; } = new List<Adquisicione>();
}
