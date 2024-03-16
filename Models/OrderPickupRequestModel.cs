using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp.Maui.Models
{
    public class OrderPickupRequestModel
    {

        public int? AccountId { get; set; }
        public int? OrderId { get; set; }
        public string BearerToken { get; set; }
    }
}
