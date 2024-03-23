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
                Title = "Ch?n ?nh giao hàng"
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
                        await App.Current.MainPage.DisplayAlert("Thành công", "B?n ?ã hoàn thành ??n hàng", "Ok");
                        var homePage = (HomePage)App.Current.MainPage;
                        homePage.RefreshOrders();
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("L?i", "Có l?i trong quá trình c?p nh?t", "Ok");
                    }
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("L?i", "Không ch?n ?nh", "Ok");
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