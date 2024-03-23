using LoginApp.Maui.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace LoginApp.Maui.Services
{
    public class OrderService : IOrderService
    {
        public async Task<List<CheckOutBillViewModel>> QueryOrderByStoreId(OrderRequestModel model)
        {
            var client = new HttpClient();
            string url = BaseUrl.url + $"/Order/GetOrderNeedToShip?IdStoreofShipper={model.IdStoreofShipper}";
            client.BaseAddress = new Uri(url);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", model.BearerToken);

            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var listOrder = JsonConvert.DeserializeObject<List<CheckOutBillViewModel>>(responseContent);
                return listOrder;
            }
            else
            {
                return null;
                throw new HttpRequestException($"Login failed with status code: {response.StatusCode}");
            }
        }

        public async Task<OrderPickupResponseModel> QueryOrderPickup(OrderPickupRequestModel model)
        {
            var result = new OrderPickupResponseModel();
            using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var client = new HttpClient();
                    string url = BaseUrl.url + $"/Order/PickupOrder?AccountId={model.AccountId}&OrderId={model.OrderId}"; ///Order/PickupOrder?AccountId=2&orderId=1111
                    //http://localhost:4000/Order/PickupOrder?AccountId=1&OrderId=268
                    client.BaseAddress = new Uri(url);

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", model.BearerToken);
                    HttpResponseMessage response = await client.GetAsync(client.BaseAddress);

                 
                    // Code xử lý yêu cầu
                    if (response.IsSuccessStatusCode)
                    {
                        result.Result = OrderPickupResult.Success;
                    }
                    else
                    {
                        result.Result = OrderPickupResult.Failure;
                        result.ErrorMessage = "An error occurred while processing the request.";
                    }
                    
                }
                catch (Exception ex)
                {
                    result.Result = OrderPickupResult.Failure;
                    result.ErrorMessage = "An error occurred while processing the request.";
                 
                }
            }

            return result;
        }
        public async Task<List<CheckOutBillViewModel>> QueryOrderCompleteByAccountID(OrderCompleteRequestModel model)
        {
            var client = new HttpClient();
            string url = BaseUrl.url + $"/Order/GetCompletedOrderByUserId?AccountId={model.AccountId}";
            client.BaseAddress = new Uri(url);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", model.BearerToken);

            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var listOrder = JsonConvert.DeserializeObject<List<CheckOutBillViewModel>>(responseContent);
                return listOrder;
            }
            else
            {
                return null;
                throw new HttpRequestException($"Login failed with status code: {response.StatusCode}");
            }
        }

        public async Task<List<CheckOutBillViewModel>> QueryOrderInProgressByAccountID(OrderInProgressRequestModel model)
        {
            var client = new HttpClient();
            string url = BaseUrl.url + $"/Order/GetOrderInProgressByUserId?AccountId={model.AccountId}";
            client.BaseAddress = new Uri(url);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", model.BearerToken);

            HttpResponseMessage response = await client.GetAsync(client.BaseAddress);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var listOrder = JsonConvert.DeserializeObject<List<CheckOutBillViewModel>>(responseContent);
                return listOrder;
            }
            else
            {
                return null;
                throw new HttpRequestException($"Login failed with status code: {response.StatusCode}");
            }
        }

        public async Task<bool> QueryUpdateImageToCompeleOrder(UpdateImageAndCompleRequestViemModel model)
        {
            var client = new HttpClient();
            string url = BaseUrl.url + $"/Order/CompleteOrder";
            client.BaseAddress = new Uri(url);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", model.BearerToken);
            string jsonRequest = JsonConvert.SerializeObject(new UpdateImageAndCompleRequestModel
            {
                DeliveryId = model.DeliveryId,
                PickUpPhoto = model.PickUpPhoto
            });
            HttpContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(client.BaseAddress, content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
                throw new HttpRequestException($"Login failed with status code: {response.StatusCode}");
            }
        }
    }
}
