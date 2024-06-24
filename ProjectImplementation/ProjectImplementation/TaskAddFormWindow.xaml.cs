using System;
using System.Linq;
using System.Windows;
using ProjectImplementation.Mdl;

namespace ProjectImplementation;

public partial class TaskAddFormWindow : Window
{
    private Druzyna druzyna { get; set; }
    private TestmasContext context;
    public TaskAddFormWindow(int teamId)
    {
        context = new TestmasContext();
        druzyna = context.Druzynas.Where(e => e.Id == teamId).FirstOrDefault();
        InitializeComponent();
    }

    ~TaskAddFormWindow()
    {
        context.Dispose();
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        if (TaskNameTextBox.Text.Length <= 4)
            new MsgBox("Nazwa zadania musi zawierać co najmniej 4 znaki!", false).Show();
        else if(DescriptionTextBox.Text.Length <= 10)
            new MsgBox("Zadanie musi posiadać co najmniej 10 znakowy opis!", false).Show();
        else if (!DeadlineDatePicker.SelectedDate.HasValue)
            new MsgBox("Musisz wybrać datę wykonania zadania!", false).Show();
        else
        {
            Druzyna.Zadanie.STATUS selectedValue;
            Druzyna.Zadanie.STATUS.TryParse(StatusComboBox.SelectedIndex.ToString(), out selectedValue);
            druzyna.dodajZadanie(
                TaskNameTextBox.Text, 
                DescriptionTextBox.Text,
                DateOnly.FromDateTime(DeadlineDatePicker.SelectedDate.GetValueOrDefault()),
                selectedValue);
            context.SaveChanges();
            new SummaryWindow(druzyna.Id).Show();
            this.Close();
        }
    }
}