using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Widget;
using SleepMonitor.Services;
using SleepMonitor.Adapter;
using Android.Support.V4.Widget;
using System;

namespace SleepMonitor.Views.Fragments
{
    public class MainPageViewFragment : Fragment
    {
        ListView _listview;
        View _view;
        SwipeRefreshLayout _swipetoRefresh;
        CustomListAdapter _adapter;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public static MainPageViewFragment NewInstance()
        {
            var main_page_fragment = new MainPageViewFragment { Arguments = new Bundle() };
            return main_page_fragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            _view = inflater.Inflate(Resource.Layout.main_page_layout, null);
            _listview = (ListView)_view.FindViewById(Resource.Id.list_view);
            _swipetoRefresh = (SwipeRefreshLayout)_view.FindViewById(Resource.Id.swipeRefresh);
 
            _adapter = new CustomListAdapter(DeviceData.Users);

            _listview.Adapter = _adapter;
            _swipetoRefresh.Refresh += _swipetoRefresh_Refresh;

            return _view;
        }

        private void _swipetoRefresh_Refresh(object sender, EventArgs e)
        {
            _adapter.NotifyDataSetChanged();
            _swipetoRefresh.Refreshing = true;
            _adapter = new CustomListAdapter(DeviceData.Users);
            _listview.Adapter = _adapter;
            _swipetoRefresh.Refreshing = false;
        }

    }
}
