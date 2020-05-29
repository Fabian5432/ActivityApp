using System.Threading.Tasks;

namespace ActivityApp.Services.Interfaces
{
    public interface ILoginService
    {   
        Task Login(string email, string password);
        Task Register(string email, string password);
        Task Logout();
        Task<bool> IsUserloggedinAsync();
    }
}