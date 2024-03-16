namespace LoginApp.Maui.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
 
        InitializeComponent();
        // Ẩn nút "Navigate Up" khi trang xuất hiện
        NavigationPage.SetHasBackButton(this, false);
        NavigationPage.SetHasNavigationBar(this, false);
    }
    private async void OnOrderPageClicked(object sender, EventArgs e)
    {
        // ?i?u h??ng ??n trang AboutPage

        await Navigation.PushAsync(new OrderPage());
    }

    private async void OnOrderCompletePageClicked(object sender, EventArgs e)
    {
        // ?i?u h??ng ??n trang ContactPage
        await Navigation.PushAsync(new OrderCompletePage());
    }

    private async void OnSignOutClicked(object sender, EventArgs e)
    {
        if (Preferences.ContainsKey(nameof(App.user)))
        {
            Preferences.Remove(nameof(App.user));
        }
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }
}