using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp.Maui.Models
{
    public static class BaseUrl
    {
        public static string url = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:4000" : "http://localhost:4000";

    }

}
