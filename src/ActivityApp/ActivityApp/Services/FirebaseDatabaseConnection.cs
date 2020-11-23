using ActivityApp.Services.Interfaces;
using Firebase.Database;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ActivityApp.Services
{
    public class FirebaseDatabaseConnection : IFirebaseDatabaseConnection
    {
        private readonly FirebaseClient _firebaseClient;

        public FirebaseDatabaseConnection()
        {
            _firebaseClient = new FirebaseClient("https://proiectdiploma-ea2e5.firebaseio.com/",
            new FirebaseOptions
            {
                AuthTokenAsyncFactory = async () => await await Task.FromResult(SecureStorage.GetAsync("token"))
            });
        }

        public FirebaseClient GetFirebaseClient()
        {  
           return _firebaseClient;
        }
    }
}