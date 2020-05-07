
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using App.Views.Fragments;
using Toolbar = Android.Widget.Toolbar;

namespace App.Views.Activities
{
    [Activity(Label = "AccountSettingsActivity")]
    public class AccountSettingsActivity : AppCompatActivity
    {
        #region Components

        private AccountSettingsFragment _accountsettingsFragment;

        #endregion

        #region LifeCycle

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            SetContentView(Resource.Layout.account_settings_page_layout);

            if (savedInstanceState != null)
            {
                _accountsettingsFragment = (AccountSettingsFragment)SupportFragmentManager.FindFragmentById(Resource.Id.account_settings_fragment_layout);
            }

            if (_accountsettingsFragment == null)
            {
                _accountsettingsFragment = AccountSettingsFragment.NewInstance();
                ReplaceFragment(_accountsettingsFragment);
            }
        }

        #endregion

        #region Methods

        public void ReplaceFragment(Android.Support.V4.App.Fragment fragment)
        {
            SupportFragmentManager.BeginTransaction()
                                  .Replace(Resource.Id.account_settings_fragment_layout, fragment)
                                  .Commit();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
                Finish();
            return base.OnOptionsItemSelected(item);
        }

        #endregion
    }
}
