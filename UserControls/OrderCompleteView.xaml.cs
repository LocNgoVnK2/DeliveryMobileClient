using LoginApp.Maui.Services;
using LoginApp.Maui.ViewModels;
using Microsoft.Maui.Controls;
using System.Globalization;

namespace LoginApp.Maui.UserControls;

public partial class OrderCompleteView : ContentView
{
    private readonly IOrderService _orderService;
    private OrderViewModel _orderVM;
    public OrderCompleteView(OrderViewModel viewModel)
    {
       
        //paymentStatus
        InitializeComponent();
        BindingContext = viewModel;

    }
    //OnReceiveOrderClicked
  
}
