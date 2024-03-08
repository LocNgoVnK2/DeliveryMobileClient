namespace LoginApp.Maui.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}
    private async void OnAboutClicked(object sender, EventArgs e)
    {
        // ?i?u h??ng ??n trang AboutPage
        await Navigation.PushAsync(new AboutPage());
    }

    private async void OnContactClicked(object sender, EventArgs e)
    {
        // ?i?u h??ng ??n trang ContactPage
        await Navigation.PushAsync(new ContactPage());
    }

    private async void OnSignOutClicked(object sender, EventArgs e)
    {
        // Th?c hi?n ??ng xu?t ? ?ây
        // Ví d?: xóa d? li?u ??ng nh?p, ?i?u h??ng v? trang ??ng nh?p, vv.
    }
}