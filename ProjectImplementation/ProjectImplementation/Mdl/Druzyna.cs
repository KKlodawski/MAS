using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectImplementation.Mdl;

public partial class Druzyna
{
    public class Zadanie
    {
        public enum STATUS
        {
            wtrakcie,
            zakonczone,
            przerwane
        }
        public int Id { get; set; }

        public string NazwaZadania { get; set; }

        public string? Opis { get; set; } 
        
        public int DruzynaId { get; set; }

        public DateOnly Termin { get; set; }

        public STATUS Status { get; set; }

        public Zadanie()
        {
        }

        public Zadanie(string nazwaZadania, string? opis, DateOnly termin, STATUS status)
        {
            NazwaZadania = nazwaZadania;
            Opis = opis;
            Termin = termin;
            Status = status;
        }

        public void zmienStatus(STATUS status)
        {
            this.Status = status;
        }

        public void zmienTermin(DateOnly termin)
        {
            this.Termin = termin;
        }
        
    }
    public int Id { get; set; }

    public string NazwaDruzyny { get; set; } = null!;

    public string Rola { get; set; } = null!;

    public static int iloscDruzyn
    {
        get
        {
            return (new TestmasContext()).Druzynas.Count();
        }
    }

    public virtual ICollection<Gra> Gras { get; } = new List<Gra>();

    public virtual ICollection<Pracownik> Pracowniks { get; } = new List<Pracownik>();

    public virtual ICollection<Zadanie> Zadanies { get; } = new List<Zadanie>();

    public Druzyna()
    {
    }
    public Druzyna(string nazwaDruzyny, string rola)
    {
        NazwaDruzyny = nazwaDruzyny;
        Rola = rola;
    }

    public Pracownik? findPracownikByPesel(string pesel)
    {
        return Pracowniks.FirstOrDefault(p => p.Pesel == pesel);
    }

    public List<Pracownik> getPracownicyDruzyny()
    {
        return Pracowniks.ToList();
    }

    public void przypiszPracownika(Pracownik p)
    {
        if (!Pracowniks.Contains(p))
        {
            if (p.Druzyna != null) throw new ArgumentException("Pracownik już należy do jakiejś drużyny!");
            else
            {
                Pracowniks.Add(p);
                p.Druzyna = this;
            }
        }
        else
        {
            throw new ArgumentException("Pracownik już należy do tej drużyny!");
        }
    }

    public Zadanie dodajZadanie(string nazwaZadania, string opis, DateOnly termin, Zadanie.STATUS status)
    {
        Zadanie z = new Zadanie(nazwaZadania, opis, termin, status);
        this.Zadanies.Add(z);
        return z;
    }

    public void usunZadanie(Zadanie z)
    {
        Zadanies.Remove(z);
    }

    public static List<Druzyna> getDruzyny()
    {
        return (new TestmasContext()).Druzynas.ToList();
    }

    public override string ToString()
    {
        return $"{NazwaDruzyny}, {Rola}";
    }
}
