using System.Windows;

namespace ProjectImplementation;

public partial class MsgBox : Window
{
    public MsgBox(string message, bool cancelButton)
    {
        InitializeComponent();
        this.MessageText.Text = message;
        if(cancelButton) CancelButton.Visibility = Visibility.Visible;
    }

    private void OkButton_OnClick(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void CancelButton_OnClick(object sender, RoutedEventArgs e)
    {
        foreach (Window window in Application.Current.Windows)
            if(window != this) 
                window.Close();
        this.Close();

    }
}