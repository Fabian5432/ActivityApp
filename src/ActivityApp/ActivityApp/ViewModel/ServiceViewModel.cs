using ActivityApp.Services;
using ActivityApp.ViewModel.Interfaces;

namespace ActivityApp.ViewModel
{
    public class ServiceViewModel: IViewModelLocatorService
    {

        public T CreateViewModelInstance<T>() where T : class, IBaseViewModel
        {
            var serviceLocator = new ServiceLocator();

            if(typeof(T)== typeof(LoginViewModel))
            {
                return new LoginViewModel(serviceLocator.GetLoginService) as T;
            }
            return null;
        }
    }
}