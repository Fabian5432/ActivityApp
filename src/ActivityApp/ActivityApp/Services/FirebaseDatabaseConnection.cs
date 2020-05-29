using ActivityApp.Services.Interfaces;
using Firebase.Database;

namespace ActivityApp.Services
{
    public class FirebaseDatabaseConnection : IFirebaseDatabaseConnection
    {
        private readonly FirebaseClient _firebaseClient;


        public FirebaseDatabaseConnection()
        {
            _firebaseClient = new FirebaseClient("https://proiectdiploma-ea2e5.firebaseio.com");
               
        }

        public FirebaseClient GetFirebaseClient()
        {
           return _firebaseClient;
        }
    }
}