using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectImplementation.Mdl;

public partial class Gra
{
    public enum GATUNKI
    {
        AKCJA,
        PRZYGODOWA,
        BIJATYKA,
        RPG,
        STATEGICZNA,
        LOGICZNA,
        SPORTOWA,
        SYMULACJA,
        FPS,
        MMO,
        HORROR,
        MUZYCZNA,
        BATLLTEROYALE,
        ROUGELIKE
    }
    public int Id { get; set; }

    public string Tytul { get; set; }

    public HashSet<GATUNKI> Gatunki { get; set; }

    public DateOnly? DataWydania { get; set; }

    public virtual ICollection<Graaktor> Graaktors { get; } = new List<Graaktor>();

    public virtual ICollection<Test> Tests { get; } = new List<Test>();

    public virtual ICollection<Druzyna> Druzynas { get; } = new List<Druzyna>();
    
    public Gra(string tytul, HashSet<GATUNKI> gatunki ,DateOnly dataWydania)
    {
        this.Tytul = tytul;
        this.DataWydania = dataWydania;
        this.Gatunki = gatunki;
    }

    public Gra(string tytul, HashSet<GATUNKI> gatunki)
    {
        this.Tytul = tytul;
        this.Gatunki = gatunki;
    }
    
    public Gra() { }


    public string getDetaleGry()
    {
        return $"Gra: {Tytul}, wydana {DataWydania}, o gatunkach: {String.Join(", ", Gatunki)}";
    }

    public void przypiszDruzyne(Druzyna druzyna)
    {
        if (!Druzynas.Contains(druzyna) || !druzyna.Gras.Contains(this))
        {
            Druzynas.Add(druzyna);
            druzyna.Gras.Add(this);
            
        } else
            throw new ArgumentException("Ta drużyna jest już przypisana do tej gry!");
        
    }

    public Graaktor dodajAktora(Aktor aktor, string postac)
    {
        if (Graaktors.Count(e => e.Aktor == aktor && e.Postac == postac) == 0 && aktor.Graaktors.Count(e => e.Aktor == aktor && e.Postac == postac) == 0 )
        {
            Graaktor ga = new Graaktor(postac, aktor, this);
            Graaktors.Add(ga);
            aktor.Graaktors.Add(ga);
            return ga;
        }
        else
            throw new ArgumentException($"Ten aktor odgrywający {postac} jest juz przypisany do tej gry!");
    }
}
