using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Widget;
using App.Services;
using App.Adapter;
using Android.Support.V4.Widget;
using System;
using Android.Support.V7.App;
using Android.Content;
using App.Activities;

namespace App.Views.Fragments
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

            _view = inflater.Inflate(Resource.Layout.main_page_layout, null);
            _listview = (ListView)_view.FindViewById(Resource.Id.list_view);
            _swipetoRefresh = (SwipeRefreshLayout)_view.FindViewById(Resource.Id.swipeRefresh);
            _adapter = new CustomListAdapter(new DeviceData().Users);
            _listview.Adapter = _adapter;

            return _view;
        }
        public override void OnResume()
        {
            base.OnResume();
            _swipetoRefresh.Refresh += _swipetoRefresh_Refresh;
            _listview.ItemClick += _itemClick;

        }
        public override void OnPause()
        {
            base.OnPause();
            _swipetoRefresh.Refresh -= _swipetoRefresh_Refresh;
            _listview.ItemClick -= _itemClick;
        }

        private void _swipetoRefresh_Refresh(object sender, EventArgs e)
        {
            _swipetoRefresh.Refreshing = true;
            Handler h = new Handler();
            Action myAction = () =>
            {
                _adapter = new CustomListAdapter(new DeviceData().Users);
                _listview.Adapter = _adapter;
                _swipetoRefresh.Refreshing = false;
            };
            h.PostDelayed(myAction, 1000);
        }

        void _itemClick(object sender, AdapterView.ItemClickEventArgs e)
        {   
            OpenScanPage(e.Position);
        }

        void OpenScanPage(int playId)
        {
            var intent = new Intent(Activity, typeof(QrCodeActivity));
            intent.PutExtra("current_play_id", playId);
            StartActivity(intent);
        }

    }
}
