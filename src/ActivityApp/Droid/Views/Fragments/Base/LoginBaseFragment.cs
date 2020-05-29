using ActivityApp.ViewModel;

namespace ActivityApp.Views.Fragments.Base
{
    public abstract class LoginBaseFragment<T> : BaseFragment<T> where T : BaseViewModel
    {
        protected LoginBaseFragment() : base(new ServiceViewModel()) { }
    }

}