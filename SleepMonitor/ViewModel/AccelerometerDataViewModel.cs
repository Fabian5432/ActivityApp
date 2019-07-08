using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SleepMonitor.Models;
using SleepMonitor.Services.Interfaces;

namespace SleepMonitor.ViewModel
{
    public class AccelerometerDataViewModel: BaseViewModel
    {
        #region Fields

        private IRepositoryService _repositoryService;
        private IConnectivityService _connectivityService;

        private AccelerometerDataModel accelerometerData;

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

        public void SendData()
        {
            _connectivityService.BluetoothWriteData(new Java.Lang.String("p"));
            
        }

        public async Task idAsync()
        {
           await _repositoryService.AddAccelerometerData();
        }
        public async Task<List<AccelerometerDataModel>> GetData()
        {
           return await _repositoryService.GetAllAccelerometerData();
        }
    }
}