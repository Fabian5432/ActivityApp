using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SleepMonitor.Services.Interfaces;

namespace SleepMonitor.ViewModel
{
    public class BluetoothConnectionViewModel : BaseViewModel
    {
        private IConnectivityService _connectivityService;

        public BluetoothConnectionViewModel(IConnectivityService connectivityService)
        {
            _connectivityService = connectivityService;
        }

        public void BluetoothConnect()
        {
            _connectivityService.BluetoothConnect();
        }

        public void BluetoothDisconnect()
        {
            _connectivityService.Disconnected();
        }
        public void WriteData()
        {
            _connectivityService.BluetoothWriteData(new Java.Lang.String("e"));
        }
    }
}