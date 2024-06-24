using System;
using System.Collections.Generic;

namespace ProjectImplementation.Mdl;

public partial class Test
{
    public enum WYNIK
    {
        ZALICZONY,
        NIEZALICZONY
    }
    public int Id { get; set; }

    public int? GraId { get; set; }

    public int? TesterId { get; set; }

    public DateOnly DataTestowania { get; set; }

    public string Komentarz { get; set; } 

    public WYNIK Wynik { get; set; }

    public virtual Gra? Gra { get; set; }

    public virtual Tester? Tester { get; set; }

    public Test()
    {
    }

    public Test(Gra g,DateOnly dataTestowania, string komentarz, WYNIK wynik)
    {
        DataTestowania = dataTestowania;
        Komentarz = komentarz;
        Wynik = wynik;
        g.Tests.Add(this);
    }
}
