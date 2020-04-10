using Android.OS;
using Android.Support.V7.App;
using Android.Views;

namespace App.Fragments
{
    public class HistoryViewFragment : Android.Support.V4.App.Fragment
    {
        private View _view;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            ((AppCompatActivity)Activity).SupportActionBar.SetTitle(Resource.String.historyPage);
            // Create your fragment here
        }

        public static HistoryViewFragment NewInstance()
        {
            var setting_fragment = new HistoryViewFragment { Arguments = new Bundle() };
            return setting_fragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            _view = inflater.Inflate(Resource.Layout.history_page_layout, null);
            return _view;
        }

    }
}
