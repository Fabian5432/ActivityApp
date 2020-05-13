using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Widget;
using App.Services;
using Android.Support.V4.Widget;
using System;
using Android.Support.V7.App;
using Android.Content;
using App.Activities;
using App.Views.Adapter;

namespace App.Views.Fragments
{   
    public class MainPageViewFragment : Fragment
    {
        #region Components

        ListView _listview;
        View _view;
        SwipeRefreshLayout _swipetoRefresh;
        ActivityListAdapter _adapter;
        Button _addButton;

        #endregion

        #region LifeCycle

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            ((AppCompatActivity)Activity).SupportActionBar.SetTitle(Resource.String.homePage);
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
            _addButton = (Button)_view.FindViewById(Resource.Id.main_page_add_button_id);
            _adapter = new ActivityListAdapter(new DeviceData().Users);
            _listview.Adapter = _adapter; 

            return _view;
        }
        public override void OnResume()
        {
            base.OnResume();
            _swipetoRefresh.Refresh += SwipetoRefresh;
            _listview.ItemClick += ItemClick;
            _addButton.Click += AddButtonClick;

        }
        public override void OnPause()
        {
            base.OnPause();
            _swipetoRefresh.Refresh -= SwipetoRefresh;
            _listview.ItemClick -= ItemClick;
            _addButton.Click -= AddButtonClick;
        }

        #endregion

        #region Methods

        private void SwipetoRefresh(object sender, EventArgs e)
        {
            _swipetoRefresh.Refreshing = true;
            Handler h = new Handler();
            void myAction()
            {
                _adapter = new ActivityListAdapter(new DeviceData().Users);
                _listview.Adapter = _adapter;
                _swipetoRefresh.Refreshing = false;
            }
            h.PostDelayed(myAction, 1000);
        }

        private void ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            OpenScanPage(e.Position);
        }

        private void AddButtonClick(object sender, EventArgs e)
        {
            var intent = new Intent(Activity, typeof(QrCodeActivity));
            StartActivity(intent);
        }

        private void OpenScanPage(int playId)
        {
            var intent = new Intent(Activity, typeof(QrCodeActivity));
            intent.PutExtra("current_play_id", playId);
            StartActivity(intent);
        }

        #endregion
    }
}
