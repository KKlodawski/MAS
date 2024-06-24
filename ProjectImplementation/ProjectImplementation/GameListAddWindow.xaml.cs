using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ProjectImplementation.Mdl;

namespace ProjectImplementation;

public partial class GameListAddWindow : Window
{
    private List<Gra> Games { get; set; }
    private Druzyna druzyna { get; set; }
    private Gra? SelectedGame { get; set; }
    private TestmasContext context;
    
    public GameListAddWindow(int teamId)
    {
        context = new TestmasContext();
        druzyna = context.Druzynas.Where(e => e.Id == teamId).FirstOrDefault();
        InitializeComponent();
        LoadData();
    }

    ~GameListAddWindow() {
        context.Dispose();
    }
    
    private void LoadData()
    {
        Games = context.Gras.ToList();
        GamesListBox.ItemsSource = Games;
    }

    private void GamesListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.AddedItems.Count <= 0)
            SelectedGame = null;
        else {
            foreach (Gra gra in e.AddedItems)
            {
                SelectedGame = gra;
            }
        }

    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        if(SelectedGame == null)
            new MsgBox("Nie wybrano gry!", false).Show();
        else
        {
            SelectedGame.przypiszDruzyne(druzyna);
            context.SaveChanges();
            new SummaryWindow(druzyna.Id).Show();
            this.Close();
        }
    }
}
