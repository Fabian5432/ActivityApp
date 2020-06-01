using Firebase.Database;
using System.Threading.Tasks;

namespace ActivityApp.Services.Interfaces
{
    public interface IFirebaseDatabaseConnection
    {
        FirebaseClient GetFirebaseClient();
    }
}