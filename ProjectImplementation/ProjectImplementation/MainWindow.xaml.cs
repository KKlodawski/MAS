using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjectImplementation.Mdl;

namespace ProjectImplementation
{
    public partial class MainWindow : Window
    {
        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();

        private string TeamName { get; set; } = "";
        private string TeamRole { get; set; } = "";

        private TestmasContext context;
        
        public MainWindow()
        {
            context = new TestmasContext();
            //InitData();
            if (context.Pracowniks.Count(e => e.DruzynaId == null) <= 0)
            {
                new MsgBox("Brak wolnych pracowników!", false).Show();
                this.Close();
            }
            InitializeComponent();
            AllocConsole();
            
            
        }

        ~MainWindow()
        {
            context.Dispose();
        }

        private void InitData()
        {
            using (var context = new TestmasContext())
            {
                try
                {
                    Pracownik p = new Pracownik("Jakub", "Laskowski",
                        DateOnly.FromDateTime(DateTime.Now.AddYears(-25)), "JLaskowski@email.pl", "305174585", 13.66m,
                        "67011225442", DateOnly.FromDateTime(DateTime.Now.AddDays(-10)),
                        new Adres("Mrągowo", "Wilczyński", 11, "16-766"), 30);
                    Pracownik p2 = new Pracownik("Kazimierz", "Andrzejewski",
                        DateOnly.FromDateTime(DateTime.Now.AddYears(-31).AddMonths(-4)), "KAndrzejewski@email.pl", "826468721", 25.26m,
                        "90060616145", DateOnly.FromDateTime(DateTime.Now.AddDays(-32)),
                        new Adres("Bydgoszcz", "Krakowiak", 31, "33-753"), 40);
                    Pracownik p3 = new Pracownik("Remigiusz", "Zieliński",
                        DateOnly.FromDateTime(DateTime.Now.AddYears(-35).AddMonths(-2)), "RZielinski@email.pl", "738638553", 18.31m,
                        "72120829249", DateOnly.FromDateTime(DateTime.Now.AddDays(-51)),
                        new Adres("Bochnia", "Skibińska", 864, "85-565"), 45);
                    Pracownik p4 = new Pracownik("Eryk", "Wiśniewski",
                        DateOnly.FromDateTime(DateTime.Now.AddYears(-38)), "EWisniewski@email.pl", "924897237", 71.03m,
                        "95110697754", DateOnly.FromDateTime(DateTime.Now.AddDays(-182)),
                        new Adres("Ryn", "Szostak", 75, "66-928"), 25);
                    Pracownik p5 = new Pracownik("Korneliusz", "Baranowski",
                        DateOnly.FromDateTime(DateTime.Now.AddYears(-21).AddMonths(-10)), "KBaranowski@email.pl", "943640540", 43.88m,
                        "97032787995", DateOnly.FromDateTime(DateTime.Now.AddMonths(-14)),
                        new Adres("Tarnowskie Góry", "Krzyżanowska", 49, "63-073"), 50);
                    context.Pracowniks.Add(p);
                    context.Pracowniks.Add(p2);
                    context.Pracowniks.Add(p3);
                    context.Pracowniks.Add(p4);
                    context.Pracowniks.Add(p5);

                    context.SaveChanges();
                    
                    Krytyk k = new Krytyk("Eugeniusz", "Wysocki", DateOnly.FromDateTime(DateTime.Now.AddYears(-35)),
                        "EWysocki@email.pl", "123123123", 28.12m, "94052375948", 105.3m, "Analiza wydajności");
                    Krytyk k2 = new Krytyk("Ryszard", "Maciejewski", DateOnly.FromDateTime(DateTime.Now.AddYears(-28)),
                        "RMaciejewski@email.pl", "123123123", 36.38m, "54020282623", 65.9m, "Analiza jakości");
                    context.Krytyks.Add(k);
                    context.Krytyks.Add(k2);

                    context.SaveChanges();
                    
                    Aktor a = new Aktor("Robert", "Kowalski",
                        DateOnly.FromDateTime(DateTime.Now.AddYears(-27).AddMonths(-2)), "RKowalski@email.pl", "700185224",
                        70.5m, "07260295267", 10.2m, 100);
                    Aktor a2 = new Aktor("Marian", "Jankowski",
                        DateOnly.FromDateTime(DateTime.Now.AddYears(-29).AddMonths(-4)), "MJankowski@email.pl", "652607217",
                        57.41m, "94051797839", 21.4m, 200);
                    context.Aktors.Add(a);
                    context.Aktors.Add(a2);

                    context.SaveChanges();
                    
                    Tester t = new Tester("Ernest", "Wasilewski", DateOnly.FromDateTime(DateTime.Now.AddYears(-57)),
                        "EWasilewska@email.com", "543993907", 40.4m, "58071367812",241m, 21);
                    Tester t2 = new Tester("Ludwik", "Cieślak", DateOnly.FromDateTime(DateTime.Now.AddYears(-31)),
                        "LCieslak@email.com", "159220560", 40.4m, "83102516947",184.7m, 7);

                    context.Testers.Add(t);
                    context.Testers.Add(t2);

                    context.SaveChanges();
                    
                    Menadzer m = new Menadzer("Marian", "Marciniak",
                        DateOnly.FromDateTime(DateTime.Now.AddYears(-43)), "MMarciniak@email.com", "526920324", 120.5m,
                        "99121888686", DateOnly.FromDateTime(DateTime.Now.AddYears(-7)),
                        new Adres("Grodków", "Piotrowska", 29, "92-861"),50,75m);
                    context.Menadzers.Add(m);

                    context.SaveChanges();
                    
                    AktorPracownik ap = new AktorPracownik("Marcel", "Krawczyk",
                        DateOnly.FromDateTime(DateTime.Now.AddYears(-33)), "MKrawczyk@email.com", "200453203", 63.8m,
                        "57021022928", 11m, 50, DateOnly.FromDateTime(DateTime.Now.AddYears(-2)),
                        new Adres("Garwolin", "Wasilewska", 6, "40-312"), 40);
                    AktorPracownik ap2 = new AktorPracownik("Fryderyk", "Baran",
                        DateOnly.FromDateTime(DateTime.Now.AddYears(-26)), "FBaran@email.com", "962637911", 54.89m,
                        "63040315787", 8.7m, 130, DateOnly.FromDateTime(DateTime.Now.AddYears(-5)),
                        new Adres("Gubin", "Młynarska", 849, "01-825"), 30);
                    
                    context.AktorPracowniks.Add(ap);
                    context.AktorPracowniks.Add(ap2);
                    
                    context.SaveChanges();

                    k.ocen(p, "Zadania wykonywane starannie z małymi pomyłkami", 8);
                    k.ocen(p3, "Znakomita wydajnosc", 10, DateOnly.FromDateTime(DateTime.Now.AddYears(-1)));
                    k2.ocen(p5, "Zadania wykonywane w terminie ale ze słabymi wynikami", 4);
                    k2.ocen(p, "Większość zadań wykonywana w czasie, zdarząją się małe opóźnienia", 7);

                    context.SaveChanges();
                    
                    Druzyna d = new Druzyna("Alfa", "Programowanie");
                    Druzyna d2 = new Druzyna("Beta", "Grafika");

                    context.Druzynas.Add(d);
                    context.Druzynas.Add(d2);

                    context.SaveChanges();

                    d.dodajZadanie("Zapytania bazodanowe", "Wykonać wszystkie niezbędne zapytania bazodanowe",
                        DateOnly.FromDateTime(DateTime.Now.AddDays(7)), Druzyna.Zadanie.STATUS.wtrakcie);
                    d.dodajZadanie("GUIBackend", "Wykonać podstawowy backend pod GUI strony głównej",
                        DateOnly.FromDateTime(DateTime.Now.AddDays(-4)), Druzyna.Zadanie.STATUS.zakonczone);
                    d2.dodajZadanie("GUI Page", "Wykonać wygląd strony głównej aplikacji",
                        DateOnly.FromDateTime(DateTime.Now.AddDays(4)), Druzyna.Zadanie.STATUS.wtrakcie);

                    context.SaveChanges();
                    
                    d.przypiszPracownika(p);
                    d.przypiszPracownika(p3);
                    d2.przypiszPracownika(p4);

                    context.SaveChanges();

                    Gra g = new Gra("Super Adventure", new HashSet<Gra.GATUNKI>
                    {
                        Gra.GATUNKI.MMO,
                        Gra.GATUNKI.AKCJA,
                        Gra.GATUNKI.RPG
                    });
                    Gra g2 = new Gra("Arena battlefield", new HashSet<Gra.GATUNKI>
                    {
                        Gra.GATUNKI.FPS
                    }, DateOnly.FromDateTime(DateTime.Now.AddYears(-2).AddMonths(-4)));

                    context.Gras.Add(g);
                    context.Gras.Add(g2);

                    context.SaveChanges();
                    
                    g.przypiszDruzyne(d);
                    g2.przypiszDruzyne(d);
                    g2.przypiszDruzyne(d2);

                    context.SaveChanges();

                    g.dodajAktora(a, "Zeus");
                    g.dodajAktora(a2, "Ares");
                    g2.dodajAktora(a, "Aster");
                    g2.dodajAktora(a2, "Chaos");

                    context.SaveChanges();

                    t.testuj(g, "Test interfejsu użytkowanika", Test.WYNIK.ZALICZONY);
                    t2.testuj(g, "Test integracji bazodanowej", Test.WYNIK.NIEZALICZONY);
                    t.testuj(g2, "Test integracji bazodanowej", Test.WYNIK.ZALICZONY,
                        DateOnly.FromDateTime(DateTime.Now.AddYears(-2).AddMonths(-6)));
                    t.testuj(g2, "Test mapy", Test.WYNIK.NIEZALICZONY,
                        DateOnly.FromDateTime(DateTime.Now.AddYears(-2).AddMonths(-8)));
                    t2.testuj(g2, "Test mapy", Test.WYNIK.ZALICZONY,
                        DateOnly.FromDateTime(DateTime.Now.AddYears(-2).AddMonths(-7)));

                    context.SaveChanges();


                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    if (e.InnerException != null)
                    {
                        Console.WriteLine(e.InnerException.Message);
                        if (e.InnerException.InnerException != null)
                        {
                            Console.WriteLine(e.InnerException.InnerException.Message);
                        }
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (context.Druzynas.Count(e => e.NazwaDruzyny == TeamName) == 0)
            {
                if (TeamName.Length <= 3 || TeamRole.Length <= 3)
                {
                    new MsgBox("Nazwa drużyny i nazwa roli powinna mieć co najmniej 4 znaki! \n Kontynuwać?", true).Show();
                }
                else
                {
                    Druzyna d = new Druzyna(TeamName, TeamRole);
                    context.Druzynas.Add(d);
                    context.SaveChanges();
                    new EmployeeListAdd(d.Id).Show();
                    this.Close();
                }
            }
            else
                new MsgBox("Drużyna o podanej nazwie już istnieje! \n Kontynuować?", true).Show();
        }

        private void TeamNameTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            TeamName = TeamNameTextBox.Text;
            Console.WriteLine(TeamName);
        }

        private void RoleTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            TeamRole = RoleTextBox.Text;
            Console.WriteLine(TeamRole);
        }
    }
}