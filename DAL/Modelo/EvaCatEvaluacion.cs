using System;
using System.Collections.Generic;

namespace DAL.Modelo;

//clase que hace referencia a las columnas de nuestra bd EvaCatEvaluacion
public partial class EvaCatEvaluacion
{
    public string CodEvaluacion { get; set; } = null!;

    public string DescEvaluacion { get; set; } = null!;

    public virtual ICollection<EvaTchNotasEvaluación>? EvaTchNotasEvaluacións { get; } = new List<EvaTchNotasEvaluación>();
}
