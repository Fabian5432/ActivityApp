using App.Services.Interfaces;

namespace App.Services
{
    public static class ServiceLocator
    {
        private static IRepositoryService _repositoryService;
        private static IQrScanService _qrScanService;

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
    }
}