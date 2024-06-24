using System;

namespace ProjectImplementation.Mdl;

public interface IPracownik
{
    public DateOnly DataZatrudnienia { get; set; }

    public Adres Adres { get; set; }

    public int CzasPracy { get; set; }

    public int getCzasZatrudnienia();
    
    
}