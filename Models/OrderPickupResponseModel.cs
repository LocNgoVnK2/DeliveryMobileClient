using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp.Maui.Models
{
    public enum OrderPickupResult
    {
        Success,
        Failure
    }
    public class OrderPickupResponseModel
    {
        public OrderPickupResult Result { get; set; }
        public string ErrorMessage { get; set; }
    }
}
