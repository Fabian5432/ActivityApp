using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Fragment = Android.Support.V4.App.Fragment;

namespace App.Views.Fragments
{
    public class ChangePasswordFragment : Fragment
    {
        #region Components

        View _view;

        #endregion

        #region LifeCycle

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            ((AppCompatActivity)Activity).SupportActionBar.SetTitle(Resource.String.changePassword);

        }
        public static ChangePasswordFragment NewInstance()
        {
            var change_password_fragment = new ChangePasswordFragment { Arguments = new Bundle() };
            return change_password_fragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            _view = inflater.Inflate(Resource.Layout.change_password_fragment_layout, null);
            return _view;
        }

        #endregion
    }
}
