using System;
using System.Collections.Generic;

namespace Gestione_Impiegati_ASPWEB.Models;

public partial class Impiegato
{
    public int ImpiegatoId { get; set; }

    public string Matricola { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string Cognome { get; set; } = null!;

    public DateTime DataNascita { get; set; }

    public string Ruolo { get; set; } = null!;

    public int RepartoRif { get; set; }

    public string? Indirizzo { get; set; }

    public string Citta { get; set; } = null!;

    public string Provincia { get; set; } = null!;

    public virtual Reparto RepartoRifNavigation { get; set; } = null!;
}
