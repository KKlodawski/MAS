using System;
using System.Collections.Generic;

namespace ProjectImplementation.Mdl;

public partial class Tester : Osoba
{
    public int Id { get; set; }

    public int? OsobaId { get; set; }

    public decimal WynagrodzenieZaTest { get; set; }

    public int Doswiadczenie { get; set; }

    public virtual Osoba? Osoba { get; set; }

    public virtual ICollection<Test> Tests { get; } = new List<Test>();
    
    public Tester(string imie, string nazwisko, DateOnly dataUrodzenia, string email, string telefon, decimal pensja, string pesel,decimal wynagrodzenieZaTest, int dowiadczenie) 
        : base(imie, nazwisko, dataUrodzenia, email, telefon, pensja, pesel)
    {
        this.WynagrodzenieZaTest = wynagrodzenieZaTest;
        this.Doswiadczenie = dowiadczenie;
    }

    public Tester(Osoba os, decimal wynagrodzenieZaTest, int dowiadczenie) 
        : base(os)
    {
        this.WynagrodzenieZaTest = wynagrodzenieZaTest;
        this.Doswiadczenie = dowiadczenie;
    }
    
    public Tester() { }
    
    public Test testuj(Gra gra, string komentarz, Test.WYNIK wynik)
    {
        Test t = new Test(gra, DateOnly.FromDateTime(DateTime.Now), komentarz, wynik);
        this.Tests.Add(t);
        return t;
    }

    public Test testuj(Gra gra, string komentarz, Test.WYNIK wynik, DateOnly data)
    {
        Test t = new Test(gra, data, komentarz, wynik);
        this.Tests.Add(t);
        return t;
    }
    
    public override decimal getPensja()
    {
        return Pensja + (WynagrodzenieZaTest * Tests.Count+1);
    }
}
