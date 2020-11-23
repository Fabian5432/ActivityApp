using System.Threading.Tasks;

namespace ActivityApp.Services.Interfaces
{
    public interface ILoginService
    {   
        Task LoginAsync(string email, string password);
        Task RegisterAsync(string email, string password);
        string GetCurrenUserEmail();
        void Logout();
    }
}