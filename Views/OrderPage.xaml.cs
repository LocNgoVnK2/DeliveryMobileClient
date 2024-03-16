using LoginApp.Maui.Models;
using LoginApp.Maui.Services;
using LoginApp.Maui.UserControls;
using LoginApp.Maui.ViewModels;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace LoginApp.Maui.Views;

public partial class OrderPage : ContentPage
{

    readonly IOrderService _orderService;

    public OrderPage()
    {

        _orderService = new OrderService();
        InitializeComponent();


        getOrderList();

    }
    public async void getOrderList()
    {
        //set up to request id
        OrderRequestModel requestModel = new OrderRequestModel();
        requestModel.IdStoreofShipper = App.user.IdStore;
        requestModel.BearerToken = App.user.Token;


        List<OrderViewModel> orders = new List<OrderViewModel>();
        List<CheckOutBillViewModel> reponse = await _orderService.QueryOrderByStoreId(requestModel);

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
            };

            var orderView = new OrderView(viewModel);
            orderView.BindingContext = viewModel;
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

    private async void OnMainClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HomePage());
    }
}