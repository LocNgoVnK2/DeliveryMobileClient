using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp.Maui.Models
{
    public class UpdateImageAndCompleRequestViemModel
    {
        public int DeliveryId { get; set; }
        public string BearerToken { get; set; }
        public string? PickUpPhoto { get; set; }
    }
    public class UpdateImageAndCompleRequestModel
    {
        public int DeliveryId { get; set; }
        public string? PickUpPhoto { get; set; }
    }
}
