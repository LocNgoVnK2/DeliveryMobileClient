using LoginApp.Maui.ViewModels;

namespace LoginApp.Maui;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {

        InitializeComponent();
        // ?n n�t "Navigate Up" khi trang xu?t hi?n
        NavigationPage.SetHasBackButton(this, false);
        NavigationPage.SetHasNavigationBar(this, false);
    }

    public LoginPage(LoginPageViewModel loginPageViewModel)
	{

		InitializeComponent();
        // ?n n�t "Navigate Up" khi trang xu?t hi?n
        NavigationPage.SetHasBackButton(this, false);
        NavigationPage.SetHasNavigationBar(this, false);
        BindingContext = loginPageViewModel;
    }
}