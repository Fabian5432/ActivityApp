using SleepMonitor.Services.Interfaces;

namespace SleepMonitor.Services
{
    public static class ServiceLocator
    {
        private static IRepositoryService _repositoryService;
        private static IConnectivityService _connectivityService;

        public static IRepositoryService GetRepositoryService
        {
            get
            {
                if (_repositoryService == null)
                    _repositoryService = new RepositoryServices();
                return _repositoryService;
            }
        }

        public static IConnectivityService GetConnectivitySeervice
        {
            get
            {
                if (_connectivityService == null)
                    _connectivityService = new ConnectivityService();
                return _connectivityService;
            }
        }
    }
}