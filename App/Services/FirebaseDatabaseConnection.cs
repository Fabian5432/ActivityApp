using App.Services.Interfaces;
using Firebase.Auth;
using Firebase.Database;

namespace App.Services
{
    public class FirebaseDatabaseConnection : IFirebaseDatabaseConnection
    {
        private readonly FirebaseClient _firebaseClient;
        private readonly FirebaseAuthProvider _firebaseAuthProvider;

        public FirebaseDatabaseConnection()
        {
            _firebaseAuthProvider = new FirebaseAuthProvider(new FirebaseConfig(""));

            _firebaseClient = new FirebaseClient("https://proiectdiploma-ea2e5.firebaseio.com");
               
        }

        public FirebaseClient GetFirebaseClient()
        {
           return _firebaseClient;
        }
    }
}