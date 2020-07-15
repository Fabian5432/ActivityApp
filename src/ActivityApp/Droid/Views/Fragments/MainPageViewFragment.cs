using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Widget;
using Android.Support.V4.Widget;
using System;
using Android.Support.V7.App;
using Android.Content;
using ActivityApp.Views.Adapter;
using ActivityApp.Views.CustomViews;
using ActivityApp.ViewModel;
using ActivityApp.Services;
using ActivityApp.Droid;

namespace ActivityApp.Views.Fragments
{
    public class MainPageViewFragment : Fragment
    {
        #region Components

        private ListView _listview;
        private View _view;
        private SwipeRefreshLayout _swipetoRefresh;
        private ActivityListAdapter _adapter;
        private Button _addButton;
        private CustomAddDialog _addDialog;
        public static ActivityItemsViewModel ViewModel { get; set; }

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
            ViewModel = new ActivityItemsViewModel(new ServiceLocator().GetDatabaseHelper);

            _view = inflater.Inflate(Resource.Layout.main_page_layout, null);
            _listview = (ListView)_view.FindViewById(Resource.Id.list_view);
            _swipetoRefresh = (SwipeRefreshLayout)_view.FindViewById(Resource.Id.swipeRefresh);
            _addButton = (Button)_view.FindViewById(Resource.Id.main_page_add_button_id);
            _adapter = new ActivityListAdapter(Activity, ViewModel);
            _addDialog = new CustomAddDialog(Activity);
            _listview.Adapter = _adapter;

            return _view;
        }

        public override void OnStart()
        {
            base.OnStart();
            if (ViewModel.Items.Count == 0)
                ViewModel.LoadItemsCommand.Execute(null);  
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
            async void RefreshAsync()
            {
                await ViewModel.LoadItemsAsync();
                _swipetoRefresh.Refreshing = false;
            }
            h.PostDelayed(RefreshAsync, 1000);
        }

        private void ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var item = ViewModel.Items[e.Position];
            var intent = new Intent(Activity, typeof(ActivityDetail));

            intent.PutExtra("data", Newtonsoft.Json.JsonConvert.SerializeObject(item));
            Activity.StartActivity(intent);
        }

        private void AddButtonClick(object sender, EventArgs e)
        {
            _addDialog.Show();
        }

        #endregion
    }
}
