using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp.Maui.ViewModels
{
    public class OrderViewModel
    {
        public int? IdOrder { get; set; }

        public string FirstName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public bool PaymentStatus { get; set; }

        public Double TotalPrice { get; set; }

        public Double ShippingFee { get; set; }
        public Double? DiscountPrice { get; set; }

    }
}
