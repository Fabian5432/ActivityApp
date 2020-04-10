using App.Services;

namespace App.ViewModel
{
    public class ServiceViewModel
    {
        public static BaseViewModel GetService<T>()
        {
            if(typeof(T) == typeof(PersonViewModel))
            {
                return new PersonViewModel(ServiceLocator.GetRepositoryService);
            }
            return null;
        }
    }
}