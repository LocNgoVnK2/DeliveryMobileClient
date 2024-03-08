namespace LoginApp.Maui;
using LoginApp.Maui.Models;
public partial class App : Application
{
    public static LoginReponseModel user;
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
}