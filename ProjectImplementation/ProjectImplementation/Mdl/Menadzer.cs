using System;
using System.Collections.Generic;

namespace ProjectImplementation.Mdl;

public partial class Menadzer : Pracownik
{
    public int? PracownikId { get; set; }

    public decimal Bonus { get; set; }

    public virtual Pracownik? Pracownik { get; set; }
    
    public Menadzer(string imie, string nazwisko, DateOnly dataUrodzenia, string email, string telefon, decimal pensja, string pesel,DateOnly dataZatrudnienia, Adres adres ,int czasPracy, decimal bonus) 
        : base(imie, nazwisko, dataUrodzenia, email, telefon, pensja, pesel,dataZatrudnienia, adres, czasPracy)
    {
        this.Bonus = bonus;
    }

    public Menadzer(Osoba os, DateOnly dataZatrudnienia, Adres adres, int czasPracy, decimal bonus) 
        : base(os, dataZatrudnienia, adres, czasPracy)
    {
        this.Bonus = bonus;
    }

    public Menadzer(Pracownik p, decimal bonus)
        : base(p, p.DataZatrudnienia, p.Adres, p.CzasPracy)
    {
        this.Bonus = bonus;
    }
    
    public Menadzer() { }

    public override decimal getPensja()
    {
        return base.getPensja() + Bonus;
    }
}
