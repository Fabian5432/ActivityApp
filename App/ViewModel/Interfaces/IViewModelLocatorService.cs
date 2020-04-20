using App.ViewModel.Interfaces;

namespace App.Views.Fragments
{
    public interface IViewModelLocatorService
    {
        T CreateViewModelInstance<T>()
            where T : class, IBaseViewModel;
    }
}