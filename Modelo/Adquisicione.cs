using System;
using System.Collections.Generic;

namespace PruebaAdres.Modelo;

public partial class Adquisicione
{
    public int AdquisicionId { get; set; }

    public double Presupuesto { get; set; }

    public int UnidadId { get; set; }

    public int TipoBienoServicioId { get; set; }

    public int Cantidad { get; set; }

    public double ValorUnitario { get; set; }

    public double ValorTotal { get; set; }

    public string FechaAdquisicion { get; set; } = null!;

    public int ProveedorId { get; set; }

    public string? Documentacion { get; set; }

    public virtual Proveedor Proveedor { get; set; } = null!;

    public virtual TipoBienoServicio TipoBienoServicio { get; set; } = null!;

    public virtual Unidad Unidad { get; set; } = null!;
}
