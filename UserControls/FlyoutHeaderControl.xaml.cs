namespace LoginApp.Maui.UserControls;

public partial class FlyoutHeaderControl : ContentView
{
	public FlyoutHeaderControl()
	{
		InitializeComponent();
		if(App.user != null)
		{
			lblUserName.Text = "Logged in as: " + App.user.Username;
			lblUserEmail.Text = App.user.Username;
		}
	}
}