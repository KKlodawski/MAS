using System;
using System.Collections.Generic;

namespace ProjectImplementation.Mdl;

public partial class Krytyk : Osoba
{
    public int? OsobaId { get; set; }

    public decimal WynagrodzenieZaOcene { get; set; }

    public string Specjalizacja { get; set; }

    public virtual Osoba? Osoba { get; set; }

    public virtual ICollection<Przegladwydajnosci> Przegladwydajnoscis { get; } = new List<Przegladwydajnosci>();
    
    public Krytyk(string imie, string nazwisko, DateOnly dataUrodzenia, string email, string telefon, decimal pensja, string pesel ,decimal wynagrodzenieZaOcene, string specjalizacja) 
        : base(imie, nazwisko, dataUrodzenia, email, telefon, pensja, pesel)
    {
        this.WynagrodzenieZaOcene = wynagrodzenieZaOcene;
        this.Specjalizacja = specjalizacja;
    }

    public Krytyk(Osoba os,decimal wynagrodzenieZaOcene, string specjalizacja) 
        : base(os)
    {
        this.WynagrodzenieZaOcene = wynagrodzenieZaOcene;
        this.Specjalizacja = specjalizacja;
    }
    
    public Krytyk() { }
    
    public override decimal getPensja()
    {
        return Pensja * (WynagrodzenieZaOcene * Przegladwydajnoscis.Count);
    }

    public Przegladwydajnosci ocen(Pracownik p, string komentarz, int ocena)
    {
        Przegladwydajnosci pw = new Przegladwydajnosci(DateOnly.FromDateTime(DateTime.Now), komentarz, this, p, ocena);
        this.Przegladwydajnoscis.Add(pw);
        return pw;
    }

    public Przegladwydajnosci ocen(Pracownik p, string komentarz, int ocena, DateOnly data)
    {
        Przegladwydajnosci pw = new Przegladwydajnosci(data, komentarz, this, p, ocena);
        this.Przegladwydajnoscis.Add(pw);
        return pw;
    }

    public override string ToString()
    {
        return base.ToString()+ $",{WynagrodzenieZaOcene}, {Specjalizacja}";
    }
}
