using System;
using System.Text.RegularExpressions;

namespace ProjectImplementation.Mdl;

public class Adres
{
    public string miasto { get; set; }
    public string ulica { get; set; }
    public int nrDomu { get; set; }
    public string kodPocztowy { get; set; }
    
    public Adres() {}
    
    public Adres(string miasto, string ulica, int nrDomu, string kodPocztowy)
    {
        if (!poprawnyKod(kodPocztowy)) throw new ArgumentException("Niepoprawny format kodu pocztowego (00-000)!");
        this.miasto = miasto;
        this.ulica = ulica;
        this.nrDomu = nrDomu;
        this.kodPocztowy = kodPocztowy;
    }

    private bool poprawnyKod(string kod)
    {
        string pattern = @"^\d{2}-\d{3}$";
        Regex regex = new Regex(pattern);
        return regex.IsMatch(kod);
    }
}