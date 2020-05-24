using Android.App;
using Android.OS;
using App.Views.Fragments;
using Android.Support.V7.App;

namespace App.Views.Activities
{
    [Activity(Label = "RegisterActivity", Theme = "@style/NoActionBar")]
    public class RegisterActivity : AppCompatActivity
    {
        #region Components

        private RegisterFragment _registerFragment;

        #endregion

        #region LifeCyle

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.register_page_layout);

            if (savedInstanceState != null)
            {
                _registerFragment = (RegisterFragment)SupportFragmentManager.FindFragmentById(Resource.Id.register_fragment_layout);
            }

            if (_registerFragment == null)
            {
                _registerFragment = RegisterFragment.NewInstance();
                ReplaceFragment(_registerFragment);
            }
            // Create your application here
        }

        #endregion

        #region Methods

        public void ReplaceFragment(Android.Support.V4.App.Fragment fragment)
        {
            SupportFragmentManager.BeginTransaction()
                                  .Replace(Resource.Id.register_fragment_layout, fragment)
                                  .Commit();
        }
        #endregion



    }
}