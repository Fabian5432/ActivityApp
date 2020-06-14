using Android.OS;
using Android.Views;
using Fragment = Android.Support.V4.App.Fragment;

namespace ActivityApp.Views.Fragments
{
    public class ErrorFragment : Fragment
    {
        private View _view;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your fragment here
        }
        public static ErrorFragment NewInstance()
        {
            var setting_fragment = new ErrorFragment { Arguments = new Bundle() };
            return setting_fragment;
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            _view = inflater.Inflate(Resource.Layout.error_fragment_page_layout, null);

            return _view;
        }
    }
}
