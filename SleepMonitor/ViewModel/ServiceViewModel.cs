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