using LoginApp.Maui.Models;
using LoginApp.Maui.Services;
using LoginApp.Maui.UserControls;
using LoginApp.Maui.ViewModels;

namespace LoginApp.Maui.Views;

public partial class HomePage : ContentPage
{
    private readonly IOrderService _orderService;
	public HomePage()
	{
        _orderService = new OrderService();
        InitializeComponent();
        // Ẩn nút "Navigate Up" khi trang xuất hiện
        NavigationPage.SetHasBackButton(this, false);
        NavigationPage.SetHasNavigationBar(this, false);
        getOrderList();
    }
    public async void getOrderList()
    {
        //set up to request id
        OrderInProgressRequestModel requestModel = new OrderInProgressRequestModel();
        requestModel.AccountId = App.user.AccountID;
        requestModel.BearerToken = App.user.Token;


        List<OrderViewModel> orders = new List<OrderViewModel>();
        List<CheckOutBillViewModel> reponse = await _orderService.QueryOrderInProgressByAccountID(requestModel);

        // Showing orders list in display 
        foreach (var order in reponse)
        {
            //create view model and push into order View component
            OrderViewModel viewModel = new OrderViewModel
            {
                IdOrder = order.IdOrder,
                FirstName = order.FirstName,
                PhoneNumber = order.PhoneNumber,
                Address = order.Address,
                PaymentStatus = (bool)order.PaymentStatus,
                TotalPrice = (double)order.TotalPrice,
                DeliveryId = order.DeliveryId
            };

            var orderView = new OrderHomeView(viewModel);

            orderStackLayout.Children.Add(orderView);
        }
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
    public async void RefreshOrders()
    {
        orderStackLayout.Children.Clear(); // Clear existing orders
        getOrderList(); // Reload orders
    }
}