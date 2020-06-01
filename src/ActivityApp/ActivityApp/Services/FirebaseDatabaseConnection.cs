using ActivityApp.Helper;
using ActivityApp.Services.Interfaces;
using Firebase.Auth;
using Firebase.Database;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using ZXing.Aztec.Internal;

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
                AuthTokenAsyncFactory = async () => await Task.FromResult(UserLocalData.userToken)
            });
        }

        public FirebaseClient GetFirebaseClient()
        {
           return _firebaseClient;
        }
    }
}