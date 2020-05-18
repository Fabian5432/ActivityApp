using App.Services;
using App.Views.Fragments;
using App.ViewModel.Interfaces;

namespace App.ViewModel
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