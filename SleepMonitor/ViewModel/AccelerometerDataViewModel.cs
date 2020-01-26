using System.Collections.Generic;
using System.Threading.Tasks;
using SleepMonitor.Models;
using SleepMonitor.Services.Interfaces;

namespace SleepMonitor.ViewModel
{
    public class AccelerometerDataViewModel: BaseViewModel
    {
        #region Fields

        private IRepositoryService _repositoryService;
        private IConnectivityService _connectivityService;

        #endregion

        public AccelerometerDataViewModel(IRepositoryService repositoryService,IConnectivityService connectivityService)
        {
            _repositoryService = repositoryService;
            _connectivityService = connectivityService;
        }

        public async Task GetAccelerometerData()
        {
            await _connectivityService.ListenForData();
        }

        public async Task AddAccelerometerData()
        {
           await _repositoryService.AddData();
        }
        public async Task<List<AccelerometerDataModel>> GetData()
        {
           return await _repositoryService.GetAllAccelerometerData();
        }
    }
}