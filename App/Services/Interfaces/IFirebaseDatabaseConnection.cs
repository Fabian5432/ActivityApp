using Firebase.Database;

namespace App.Services.Interfaces
{
    public interface IFirebaseDatabaseConnection
    {
        FirebaseClient GetFirebaseClient();
    }
}