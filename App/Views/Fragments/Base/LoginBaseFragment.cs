using App.ViewModel;

namespace App.Views.Fragments.Base
{
    public abstract class LoginBaseFragment<T> : BaseFragment<T> where T : BaseViewModel
    {
        protected LoginBaseFragment() : base(new ServiceViewModel()) { }
    }

}