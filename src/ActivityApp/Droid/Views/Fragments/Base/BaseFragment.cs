using ActivityApp.ViewModel.Interfaces;
using Android.Support.V4.App;

namespace ActivityApp.Views.Fragments
{
    public abstract class BaseFragment<TViewModel> : Fragment
                                  where TViewModel : class, IBaseViewModel
    {
        public TViewModel ViewModel { get; set; }

        public IViewModelLocatorService ViewModelLocatorService { get;}


        protected BaseFragment(IViewModelLocatorService viewModelLocator)
        {
            ViewModelLocatorService = viewModelLocator;
            ViewModel = ViewModelLocatorService?.CreateViewModelInstance<TViewModel>();
        }

        public BaseFragment(TViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        protected BaseFragment()
        {

        }
    }
}