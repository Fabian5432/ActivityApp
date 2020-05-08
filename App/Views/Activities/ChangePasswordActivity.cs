
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using App.Views.Fragments;
using Toolbar = Android.Widget.Toolbar;

namespace App.Views.Activities
{
    [Activity(Label = "ChangePasswordActivity")]
    public class ChangePasswordActivity : AppCompatActivity
    {
        #region Components

        private ChangePasswordFragment _changepasswordFragment;

        #endregion

        #region LifeCycle

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            SetContentView(Resource.Layout.change_password_page_layout);

            if (savedInstanceState != null)
            {
                _changepasswordFragment = (ChangePasswordFragment)SupportFragmentManager.FindFragmentById(Resource.Id.change_password_fragment_layout);
            }

            if (_changepasswordFragment == null)
            {
                _changepasswordFragment = ChangePasswordFragment.NewInstance();
                ReplaceFragment(_changepasswordFragment);
            }
        }

        #endregion

        #region Methods

        public void ReplaceFragment(Android.Support.V4.App.Fragment fragment)
        {
            SupportFragmentManager.BeginTransaction()
                                  .Replace(Resource.Id.change_password_fragment_layout, fragment)
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
