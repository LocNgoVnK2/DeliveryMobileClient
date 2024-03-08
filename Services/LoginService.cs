using LoginApp.Maui.Models;
using Microsoft.Maui.ApplicationModel.Communication;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;


namespace LoginApp.Maui.Services
{
    public class LoginService : ILoginService
    {
        public async Task<LoginReponseModel> Login(string username, string password)
        {
            /*
             
             http://localhost:4000/users
             */


            var client = new HttpClient();
            string url = BaseUrl.url + "/users/authenticate";
            client.BaseAddress = new Uri(url);
            var user = new LoginRequestModel { userName = username, passWord = password };

            //  đổi User object thành JSON type
            var jsonString = JsonConvert.SerializeObject(user);

            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(client.BaseAddress, content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var authenticatedUser = JsonConvert.DeserializeObject<LoginReponseModel>(responseContent);
                return authenticatedUser;
            }
            else
            {
                return null;
                throw new HttpRequestException($"Login failed with status code: {response.StatusCode}");
            }
            /*
            var user = new LoginRequestModel { userName = username, passWord = password };

            //  đổi User object thành JSON type
            var jsonString = JsonConvert.SerializeObject(user);

            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            string url = BaseUrl.url + "/users/authenticate";
            var response = await _httpClient.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var authenticatedUser = JsonConvert.DeserializeObject<LoginReponseModel>(responseContent);
                return authenticatedUser;
            }
            else
            {
                throw new HttpRequestException($"Login failed with status code: {response.StatusCode}");
            }
            */
        }
    }
}
