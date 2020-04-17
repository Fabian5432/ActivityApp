using App.Services.Interfaces;

namespace App.Services
{
    public static class ServiceLocator
    {
        private static IRepositoryService _repositoryService;
        private static IQrScanService _qrScanService;
        private static ILoginService _loginService;

        public static IRepositoryService GetRepositoryService
        {
            get
            {
                if (_repositoryService == null)
                    _repositoryService = new RepositoryServices();
                return _repositoryService;
            }
        }

        public static IQrScanService GetQrScanService
        {
            get
            {  
                _qrScanService = new QrCodeService();
                return _qrScanService;
            }
        }

        public static ILoginService GetLoginService
        {
            get
            {   //if(_loginService == null)
                _loginService = new LoginService();
                return _loginService;
            }
        }
    }
}