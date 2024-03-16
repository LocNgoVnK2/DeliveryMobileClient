using LoginApp.Maui.Models;
using LoginApp.Maui.Services;
using LoginApp.Maui.ViewModels;
using LoginApp.Maui.Views;
using Microsoft.Maui.Controls.Compatibility;
using System.Diagnostics;

namespace LoginApp.Maui.UserControls;

public partial class OrderView : ContentView
{
    private readonly IOrderService _orderService;
    private OrderViewModel _orderVM;
    public OrderView(OrderViewModel viewModel)
	{
        _orderVM = viewModel;
        _orderService = new OrderService();
		InitializeComponent();
	}
    //OnReceiveOrderClicked
    private async void OnReceiveOrderClicked(object sender, EventArgs e)
    {
        // call api nhận 
        //set up to request id
        OrderPickupRequestModel requestModel = new OrderPickupRequestModel
        {
            AccountId = App.user.AccountID,
            BearerToken = App.user.Token,
            OrderId = _orderVM.IdOrder
        };



        OrderPickupResponseModel response = await _orderService.QueryOrderPickup(requestModel);
        if (response.Result == OrderPickupResult.Success)
        {
            //await DisplayAlert("Success", "Order received successfully", "OK");
            await App.Current.MainPage.DisplayAlert("Success", "Hóa đơn đã được nhận bởi thành công bởi bạn", "OK");
            await Navigation.PushAsync(new OrderPage());
        }
        else
        {
            await App.Current.MainPage.DisplayAlert("Fail", "Có lỗi xảy ra trong quá trình nhận đơn hàng", "OK");
        }
  

    }

}