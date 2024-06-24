using System;
using System.Collections.Generic;

namespace ProjectImplementation.Mdl;

public partial class Przegladwydajnosci
{
    public int Id { get; set; }
    public DateOnly DataPrzegladu { get; set; }

    public string Komentarz { get; set; } = null!;

    public int Ocena { get; set; }

    public int? PracownikId { get; set; }

    public int? KrytykId { get; set; }

    public virtual Krytyk? Krytyk { get; set; }

    public virtual Pracownik? Pracownik { get; set; }
    
    public Przegladwydajnosci(DateOnly dataPrzglądu, string komentarz, Krytyk krytyk, Pracownik pracownik,int ocena)
    {
        if (ocena is <= 0 or > 10) throw new ArgumentException("Ocena powinna być z przedziału 1:10");
        this.DataPrzegladu = dataPrzglądu;
        this.Komentarz = komentarz;
        this.Krytyk = krytyk;
        this.Pracownik = pracownik;
        this.Ocena = ocena;
        pracownik.addPrzegladWydajnosci(this);
    }

    public Przegladwydajnosci() { }
    
    public void setPracownik(Pracownik p)
    {
        this.Pracownik = p;
    }

    public Pracownik getPracownik()
    {
        return this.Pracownik;
    }

    public string getDetalePrzeglądu()
    {
        return $"Przegląd odbył się {DataPrzegladu}\n Zakończył się oceną: {Ocena} \n {Komentarz} ";
    }

    public override string ToString()
    {
        return $"{Pracownik.Imie}, {Krytyk.Imie}, {DataPrzegladu}, {Komentarz}, {Ocena}";
    }
}
