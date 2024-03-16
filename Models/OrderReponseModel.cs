using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp.Maui.Models
{
    public class CheckOutBillViewModel
    {
        public int? IdOrder { get; set; }
        public int? CustomerId { get; set; }
        public string? Note { get; set; }
        public bool? IsReceived { get; set; }
        public bool? IsAccept { get; set; }


        public DateTime? OrderDate { get; set; }
        public Double? TotalPrice { get; set; }
        public Double? ShippingFee { get; set; }
        public Double? DiscountPrice { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public int? AccountID { get; set; }
        public string? employeeName { get; set; }

        public bool? PaymentStatus { get; set; }
        public int? IdStore { get; set; }

        public int? DeliveryId { get; set; }
    }


    public class OrderReponseModel
    {
        public List<CheckOutBillViewModel> checkOutBillViewModels { get; set; }
    }
}
