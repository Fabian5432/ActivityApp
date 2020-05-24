using App.Services.Interfaces;

namespace App.Services
{
    public class ServiceLocator
    {
        private static IRepositoryService _repositoryService;
        private static IQrScanService _qrScanService;
        private static ILoginService _loginService;
        private static IFirebaseDatabaseConnection _firebaseDatabaseConnection;
        private static IFirebaseDatabaseHelper _firebaseDatabaseHelper;

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
                    _loginService = new LoginService(GetDatabaseHelper);
                return _loginService;
            }
        }
    }
}