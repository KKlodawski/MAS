using System;
using System.Collections.Generic;

namespace ProjectImplementation.Mdl;

public partial class Graaktor
{
    public int GraId { get; set; }

    public int AktorId { get; set; }

    public string Postac { get; set; } = null!;

    public virtual Aktor Aktor { get; set; } = null!;

    public virtual Gra Gra { get; set; } = null!;

    public Graaktor(string postac, Aktor aktor, Gra gra)
    {
        Postac = postac;
        Aktor = aktor;
        Gra = gra;
    }

    public Graaktor()
    {
    }
}
