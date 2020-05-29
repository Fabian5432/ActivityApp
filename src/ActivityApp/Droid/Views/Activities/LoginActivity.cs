using Android.App;
using Android.OS;
using Android.Support.V7.App;
using ActivityApp.Views.Fragments;

namespace ActivityApp.Activities
{
    [Activity(Label = "@string/app_name", NoHistory = true, Theme = "@style/NoActionBar")]
    public class LoginActivity : AppCompatActivity
    {
        #region Components

        private LoginFragment _loginFragment;

        #endregion

        #region LifeCycle

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.login_page_layout);

            if (savedInstanceState != null)
            {
                _loginFragment = (LoginFragment)SupportFragmentManager.FindFragmentById(Resource.Id.login_fragment_layout);
            }

            if (_loginFragment == null)
            {
                _loginFragment = LoginFragment.NewInstance();
                ReplaceFragment(_loginFragment);
            }
        }

        #endregion

        #region Methods

        public void ReplaceFragment(Android.Support.V4.App.Fragment fragment)
        {
            SupportFragmentManager.BeginTransaction()
                                  .Replace(Resource.Id.login_fragment_layout, fragment)
                                  .Commit();
        }

        #endregion
    }
}