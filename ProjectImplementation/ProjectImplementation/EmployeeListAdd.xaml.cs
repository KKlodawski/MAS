using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ProjectImplementation.Mdl;

namespace ProjectImplementation;

public partial class EmployeeListAdd : Window
{
    private List<Pracownik> Employees { get; set; }
    private List<Pracownik> SelectedEmployees { get; set; } = new List<Pracownik>();
    private Druzyna druzyna { get; set; }
    private TestmasContext context;
    
    public EmployeeListAdd(int teamId)
    {
        context = new TestmasContext();
        druzyna = context.Druzynas.Where(e => e.Id == teamId).FirstOrDefault();
        InitializeComponent();
        LoadEmployees();
        EmployeeListBox.ItemsSource = Employees;
    }

    ~EmployeeListAdd()
    {
        context.Dispose();
    }
    
    private void LoadEmployees()
    {
        Employees = context.Pracowniks.Where(e => e.DruzynaId == null).ToList();
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        if(SelectedEmployees.Count <= 0) 
            new MsgBox("Nie wybrano żadnego pracownika! \n Kontynuować?", true).Show();
        else
        {
            foreach (Pracownik pracownik in SelectedEmployees)
            {
                druzyna.przypiszPracownika(pracownik);
            }

            context.SaveChanges();
            //Console.WriteLine(String.Join(",", SelectedEmployees.Select(e => e.Id)));
            new SummaryWindow(druzyna.Id).Show();
            this.Close();
        }
    }

    private void EmployeeListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        foreach (Pracownik pracownik in e.AddedItems)
        {
            if(!SelectedEmployees.Contains(pracownik))
                SelectedEmployees.Add(pracownik);
        }
        foreach (Pracownik pracownik in e.RemovedItems)
        {
            if (SelectedEmployees.Contains(pracownik))
                SelectedEmployees.Remove(pracownik);
        }
        Console.WriteLine(String.Join(",", SelectedEmployees.Select(e => e.Imie)));
    }
}
