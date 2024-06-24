using System;
using System.Collections.Generic;

namespace ProjectImplementation.Mdl;

public abstract class Osoba
{
    public int Id { get; set; }
    public string Pesel { get; set; }
    private static List<string> Pesels { get; set; } = new List<string>();
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public DateOnly DataUrodzenia { get; set; }
    public string Email { get; set; }
    public string Telefon { get; set; } 
    public decimal Pensja { get; set; }
    public virtual ICollection<Krytyk> Krytyks { get; } = new List<Krytyk>();
    public virtual ICollection<Tester> Testers { get; } = new List<Tester>();

    protected Osoba () { }
    protected Osoba(string imie, string nazwisko, DateOnly dataUrodzenia, string email, string telefon, decimal pensja, string pesel)
    {
        if (telefon.Length is > 9 or < 9) throw new AggregateException("Długość numeru telefonu powinna być 9");
        if (pesel.Length is > 11 or < 11) throw new ArgumentException("Długość peselu powinna być 11");
        if (Pesels.Contains(pesel)) throw new ArgumentException("Nieunikatowy pesel");
        Pesels.Add(pesel);
        this.Pesel = pesel;
        this.Imie = imie;
        this.Nazwisko = nazwisko;
        this.DataUrodzenia = dataUrodzenia;
        this.Email = email;
        this.Telefon = telefon;
        this.Pensja = pensja;
    }

    protected Osoba(Osoba os)
    {
        this.Imie = os.Imie;
        this.Nazwisko = os.Nazwisko;
        this.DataUrodzenia = os.DataUrodzenia;
        this.Email = os.Email;
        this.Telefon = os.Telefon;
        this.Pensja = os.Pensja;
        this.Pesel = os.Pesel;
    }

    public abstract decimal getPensja();

    public override string ToString()
    {
        return $"{Imie}, {Nazwisko}, {DataUrodzenia}, {Email}, {Telefon}, {Pensja}, {Pesel}";
    }
}
