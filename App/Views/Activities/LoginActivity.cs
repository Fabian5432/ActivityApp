using Android.App;
using Android.OS;
using App.Views.Fragments;
using Android.Support.V7.App;

namespace App.Activities
{
    [Activity(Label = "@string/app_name", NoHistory =true)]
    public class LoginActivity : AppCompatActivity
    {
        #region Components


        private LoginFragment _loginFragment;


        #endregion

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


        public void ReplaceFragment(Android.Support.V4.App.Fragment fragment)
        {
            SupportFragmentManager.BeginTransaction()
                                  .Replace(Resource.Id.login_fragment_layout, fragment)
                                  .Commit();
        }

    }
}