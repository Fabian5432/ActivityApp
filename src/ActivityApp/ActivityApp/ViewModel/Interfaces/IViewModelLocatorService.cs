
namespace ActivityApp.ViewModel.Interfaces
{
    public interface IViewModelLocatorService
    {
        T CreateViewModelInstance<T>()
            where T : class, IBaseViewModel;
    }
}