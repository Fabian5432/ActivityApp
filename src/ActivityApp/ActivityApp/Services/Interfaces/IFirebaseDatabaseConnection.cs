using Firebase.Database;

namespace ActivityApp.Services.Interfaces
{
    public interface IFirebaseDatabaseConnection
    {
        FirebaseClient GetFirebaseClient();
    }
}