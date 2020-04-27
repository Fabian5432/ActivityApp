using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using App.Services;
using App.Views.Adapter;

namespace App.Fragments
{
    public class HistoryViewFragment : Android.Support.V4.App.Fragment
    {
        private View _view;
        ListView _listview;
        HistoryListAdapter _adapter;

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
            _listview = (ListView)_view.FindViewById(Resource.Id.history_list_view);
            _adapter = new HistoryListAdapter(new HistoryData().Activity);
            _listview.Adapter = _adapter;
            return _view;
        }

    }
}
