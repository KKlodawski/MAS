using System;
using System.Collections.Generic;
using ProjectImplementation.Mdl;

namespace ProjectImplementation.Mdl;

public partial class Pracownik : Osoba, IPracownik
{
    public int? OsobaId { get; set; }
    public DateOnly DataZatrudnienia { get; set; }
    public Adres Adres { get; set; }
    public int CzasPracy { get; set; }
    public virtual Menadzer Menadzer { get; }
    public virtual ICollection<Przegladwydajnosci> Przegladwydajnoscis { get; } = new List<Przegladwydajnosci>();
    public int? DruzynaId { get; set; }
    public virtual Druzyna Druzyna { get; set; } 
    
    public Pracownik() { }
    
    public Pracownik(string imie, string nazwisko, DateOnly dataUrodzenia, string email, string telefon, decimal pensja, string pesel, DateOnly dataZatrudnienia, Adres adres, int czasPracy) 
        : base(imie, nazwisko, dataUrodzenia, email, telefon, pensja, pesel)
    {
        this.DataZatrudnienia = dataZatrudnienia;
        this.Adres = adres;
        this.CzasPracy = czasPracy;
    }
    
    public Pracownik(Osoba os, DateOnly dataZatrudnienia, Adres adres, int czasPracy) 
        : base(os)
    {
        this.DataZatrudnienia = dataZatrudnienia;
        this.Adres = adres;
        this.CzasPracy = czasPracy;
    }

    public ICollection<Przegladwydajnosci> getPrzegladyWydajnosci()
    {
        return this.Przegladwydajnoscis;
    }

    public void addPrzegladWydajnosci(Przegladwydajnosci pw)
    {
        if(!this.Przegladwydajnoscis.Contains(pw)) this.Przegladwydajnoscis.Add(pw);
    }
    
    public DateOnly getDataZatrudnienia()
    {
        return this.DataZatrudnienia;
    }

    public int getCzasZatrudnienia()
    {
        DateOnly today = DateOnly.FromDateTime(DateTime.Now);
        int daysDiff = (today.ToDateTime(TimeOnly.MinValue) - DataZatrudnienia.ToDateTime(TimeOnly.MinValue)).Days;
        return daysDiff;
    }

    public int getCzasPracy()
    {
        return this.CzasPracy;
    }

    public Adres getAdres()
    {
        return this.Adres;
    }

    public override decimal getPensja()
    {
        return Pensja * CzasPracy;
    }

    public override string ToString()
    {
        return base.ToString() + $",{DataZatrudnienia}, {Adres}, {CzasPracy}";
    }
}
