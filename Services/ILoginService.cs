using LoginApp.Maui.Models;

namespace LoginApp.Maui.Services;

public interface ILoginService
{
    Task<LoginReponseModel> Login(string username, string password);

}
