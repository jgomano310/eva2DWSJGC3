using System;
using System.Collections.Generic;

namespace DAL.Modelo;
//clase que hace referencia a las columnas de nuestra bd EvaTchNotasEvaluación
public partial class EvaTchNotasEvaluación
{
    public string MdUuid { get; set; } = null!;

    public DateTime MdFch { get; set; }

    public int IdNotaEvaluacion { get; set; }

    public string CodAlumno { get; set; } = null!;

    public long NotaEvaluacion { get; set; }

    public string CodEvaluacion { get; set; } = null!;

    public virtual EvaCatEvaluacion? CodEvaluacionNavigation { get; set; } = null!;
}
