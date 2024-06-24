using System;
using System.Collections.Generic;

namespace ProjectImplementation.Mdl;

public partial class Aktor : Osoba
{
    public decimal ZaplataZaLinie { get; set; }

    public int IloscLinii { get; set; }
    
    public decimal Zarobek {
        get {
            return IloscLinii*ZaplataZaLinie;
        }
    }

    public virtual ICollection<Graaktor> Graaktors { get; } = new List<Graaktor>();
    
    public virtual AktorPracownik AktorPracownik { get; set; }

    public Aktor(string imie, string nazwisko, DateOnly dataUrodzenia, string email, string telefon, decimal pensja, string pesel,decimal zaplataZaLinie, int iloscLinii) 
        : base(imie, nazwisko, dataUrodzenia, email, telefon, pensja, pesel)
    {
        this.ZaplataZaLinie = zaplataZaLinie;
        this.IloscLinii = iloscLinii;
    }

    public Aktor(Osoba os, decimal zaplataZaLinie, int iloscLinii) 
        : base(os)
    {
        this.ZaplataZaLinie = zaplataZaLinie;
        this.IloscLinii = iloscLinii;
    }
    
    public Aktor() { }
    
    public override decimal getPensja()
    {
        return Pensja + Zarobek;
    }
}
