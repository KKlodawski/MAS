using System.Collections.Generic;
using System.Linq;
using System.Windows;
using ProjectImplementation.Mdl;

namespace ProjectImplementation;

public partial class SummaryWindow : Window
{
    private List<Pracownik> Employees { get; set; }
    //public List<Task> Tasks { get; set; }
    private Druzyna druzyna { get; set; }
    private TestmasContext context;
    private Gra gra { get; set; }
    private List<Druzyna.Zadanie> Zadania { get; set; } = new List<Druzyna.Zadanie>();
    
    public SummaryWindow(int teamId)
    {
        context = new TestmasContext();
        druzyna = context.Druzynas.Where(e => e.Id == teamId).FirstOrDefault();
        InitializeComponent();
        LoadData();
    }
    
    ~SummaryWindow() {
        context.Dispose();
    }
    
    private void LoadData()
    {
        Employees = context.Pracowniks.Where(e => e.DruzynaId == druzyna.Id).ToList();
        EmployeeListBox.ItemsSource = Employees;

        TeamNameTextBox.Text = druzyna.NazwaDruzyny;

        gra = context.Gras.Where(e => e.Druzynas.Contains(druzyna)).FirstOrDefault();
        if(gra != null)
        {
            GameNameTextBox.Text = gra.Tytul;
            AssignGameButton.Visibility = Visibility.Collapsed;
        }

        Zadania = context.Zadanies.Where(e => e.DruzynaId == druzyna.Id).ToList();
        TaskListBox.ItemsSource = Zadania;

        //TaskListBox.ItemsSource = Tasks;
    }
    

    private void Confirm_OnClick(object sender, RoutedEventArgs e)
    {
        new MsgBox("Drużyna została dodana!", false).Show();
        this.Close();
    }

    private void GameButton_OnClick(object sender, RoutedEventArgs e)
    {
        if(context.Gras.ToList().Count <= 0)
            new MsgBox("Brak gier do przypisania!", false).Show();
        else {
            new GameListAddWindow(druzyna.Id).Show();
            this.Close();
        }
    }

    private void TaskButton_OnClick(object sender, RoutedEventArgs e)
    {
        new TaskAddFormWindow(druzyna.Id).Show();
        this.Close();
    }
}


