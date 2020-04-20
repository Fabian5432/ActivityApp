using App.Services.Interfaces;

namespace App.Services
{
    public class ServiceLocator
    {
        private static IRepositoryService _repositoryService;
        private static IQrScanService _qrScanService;
        private static ILoginService _loginService;

        public IRepositoryService GetRepositoryService
        {
            get
            {
                if (_repositoryService == null)
                    _repositoryService = new RepositoryServices();
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
                _loginService = new LoginService();
                return _loginService;
            }
        }
    }
}