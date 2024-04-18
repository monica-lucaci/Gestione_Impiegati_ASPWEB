﻿using System;
using System.Collections.Generic;

namespace Gestione_Impiegati_ASPWEB.Models;

public partial class Reparto
{
    public int RepartoId { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Impiegato> Impiegatos { get; set; } = new List<Impiegato>();
}
