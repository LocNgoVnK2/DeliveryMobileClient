using LoginApp.Maui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp.Maui.Services
{
    public interface IOrderService
    {
        Task<List<CheckOutBillViewModel>> QueryOrderByStoreId(OrderRequestModel model);
        Task<OrderPickupResponseModel> QueryOrderPickup(OrderPickupRequestModel model);
        Task<List<CheckOutBillViewModel>> QueryOrderCompleteByAccountID(OrderCompleteRequestModel model);
    }
}
