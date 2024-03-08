using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp.Maui.Models
{
    public class LoginReponseModel
    {
        public int AccountID { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
        public int IdStore { get; set; }
    }
}
