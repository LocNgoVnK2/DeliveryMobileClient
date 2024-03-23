using LoginApp.Maui.Models;
using LoginApp.Maui.Services;
using LoginApp.Maui.ViewModels;
using LoginApp.Maui.Views;

namespace LoginApp.Maui.UserControls;

public partial class OrderHomeView : ContentView
{
    private readonly OrderViewModel _orderVM;
    private readonly IOrderService _orderService;
    public OrderHomeView(OrderViewModel model)
	{
        _orderVM = model;
        BindingContext = model;
        _orderService = new OrderService();
        InitializeComponent();
	}


    //OnCompleteOrderClicked
    private async void OnCompleteOrderClicked(object sender, EventArgs e)
    {
        try
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Ch?n ?nh giao h�ng"
            });

            if (result != null)
            {
                using (var stream = await result.OpenReadAsync())
                {
                    // Convert image stream to base64 string
                    string imageBase64 = ConvertToBase64(stream);

                    // Proceed with sending the base64 string to your server
                    UpdateImageAndCompleRequestViemModel model = new UpdateImageAndCompleRequestViemModel()
                    {
                        BearerToken = App.user.Token,
                        DeliveryId = (int)_orderVM.DeliveryId,
                        PickUpPhoto = imageBase64
                    };

                    var response = await _orderService.QueryUpdateImageToCompeleOrder(model);
                    if (response)
                    {
                        await App.Current.MainPage.DisplayAlert("Th�nh c�ng", "B?n ?� ho�n th�nh ??n h�ng", "Ok");
                        var homePage = (HomePage)App.Current.MainPage;
                        homePage.RefreshOrders();
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("L?i", "C� l?i trong qu� tr�nh c?p nh?t", "Ok");
                    }
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("L?i", "Kh�ng ch?n ?nh", "Ok");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private string ConvertToBase64(Stream stream)
    {
        using (MemoryStream memoryStream = new MemoryStream())
        {
            stream.CopyTo(memoryStream);
            byte[] imageBytes = memoryStream.ToArray();
            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }
    }


}