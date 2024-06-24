using System;

namespace ProjectImplementation.Mdl;

public class AktorPracownik : Aktor, IPracownik
{
    public DateOnly DataZatrudnienia { get; set; }
    public Adres Adres { get; set; }
    public int CzasPracy { get; set; }
    
    public int? AktorId { get; set; }
    public virtual Aktor? Aktor { get; set; }

    public AktorPracownik(string imie, string nazwisko, DateOnly dataUrodzenia, string email, string telefon, decimal pensja, string pesel,decimal zaplataZaLinie, int iloscLinii, DateOnly dataZatrudnienia, Adres adres, int czasPracy) 
        : base(imie, nazwisko, dataUrodzenia, email, telefon, pensja, pesel,zaplataZaLinie, iloscLinii)
    {
        this.DataZatrudnienia = dataZatrudnienia;
        this.Adres = adres;
        this.CzasPracy = czasPracy;
    }

    public AktorPracownik(Osoba os, decimal zaplataZaLinie, int iloscLinii, DateOnly dataZatrudnienia, Adres adres, int czasPracy) 
        : base(os, zaplataZaLinie, iloscLinii)
    {
        this.DataZatrudnienia = dataZatrudnienia;
        this.Adres = adres;
        this.CzasPracy = czasPracy;
    }
    
    public AktorPracownik() { }

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
}