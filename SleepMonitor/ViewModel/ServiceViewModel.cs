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
using SleepMonitor.Services;

namespace SleepMonitor.ViewModel
{
    public class ServiceViewModel
    {
        public static BaseViewModel GetService<T>()
        {
            if (typeof(T) == typeof(AccelerometerDataViewModel))
            {
                return new AccelerometerDataViewModel(ServiceLocator.GetRepositoryService,ServiceLocator.GetConnectivitySeervice);
            }
            else if(typeof(T) == typeof(PersonViewModel))
            {
                return new PersonViewModel(ServiceLocator.GetRepositoryService);
            }
            else if(typeof(T)==typeof(BluetoothConnectionViewModel))
            {
                return new BluetoothConnectionViewModel(ServiceLocator.GetConnectivitySeervice);
            }
            return null;
        }
    }
}