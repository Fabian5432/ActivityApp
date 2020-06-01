using ActivityApp.Services.Interfaces;
using Firebase.Auth;

namespace ActivityApp.Services
{
    public class ServiceLocator
    {
        private static IRepositoryService _repositoryService;
        private static IQrScanService _qrScanService;
        private static ILoginService _loginService;
        private static IFirebaseDatabaseConnection _firebaseDatabaseConnection;
        private static IFirebaseDatabaseHelper _firebaseDatabaseHelper;
        private static IFirebaseAuthProvider _firebaseAuthProvider;

        public IFirebaseAuthProvider GetFirebaseAuthProvider
        {
            get
            {
                if (_firebaseAuthProvider == null)
                    _firebaseAuthProvider = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyA-Ii9kue7tBwdPhqMRN7auPkW_77JbKPQ"));
                return _firebaseAuthProvider;
            }
        }

        public IFirebaseDatabaseConnection GetFirebaseDatabaseConnection
        {
            get
            {
                if (_firebaseDatabaseConnection == null)
                    _firebaseDatabaseConnection = new FirebaseDatabaseConnection();
                return _firebaseDatabaseConnection;
            }
        }

        public IFirebaseDatabaseHelper GetDatabaseHelper
        {
            get
            {
                if (_firebaseDatabaseHelper == null)
                    _firebaseDatabaseHelper = new FirebaseDatabaseHelper(GetFirebaseDatabaseConnection);
                return _firebaseDatabaseHelper;
            }
        }

        public IRepositoryService GetRepositoryService
        {
            get
            {
                if (_repositoryService == null)
                    _repositoryService = new RepositoryService(GetDatabaseHelper);
                return _repositoryService;
            }
        }

        public IQrScanService GetQrScanService
        {
            get
            {  
                _qrScanService = new QrCodeService();
                return _qrScanService;
            }
        }

        public ILoginService GetLoginService
        {
            get
            {   if(_loginService == null)
                    _loginService = new LoginService(GetDatabaseHelper, GetFirebaseAuthProvider);
                return _loginService;
            }
        }
    }
}