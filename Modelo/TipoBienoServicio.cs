using System;
using System.Collections.Generic;

namespace PruebaAdres.Modelo;

public partial class TipoBienoServicio
{
    public int TipoBienoServicioId { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Adquisicione> Adquisiciones { get; set; } = new List<Adquisicione>();
}
