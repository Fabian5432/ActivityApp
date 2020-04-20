using Android.Support.V4.App;
using App.ViewModel.Interfaces;


namespace App.Views.Fragments
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

        BaseFragment(TViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        protected BaseFragment()
        {

        }
    }
}