using System.Threading.Tasks;
using Firebase.Auth;

namespace ActivityApp.Services.Interfaces
{
    public interface ILoginService
    {   
        Task Login(string email, string password);
        Task Register(string email, string password);
        string GetCurrenUserEmail();
        void Logout();
        FirebaseAuthLink Auth { get; set; }
    }
}