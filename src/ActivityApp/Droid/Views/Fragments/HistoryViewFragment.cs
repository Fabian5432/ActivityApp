using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using ActivityApp.Views.Adapter;
using Fragment = Android.Support.V4.App.Fragment;
using ActivityApp.ViewModel;
using ActivityApp.Services;

namespace ActivityApp.Fragments
{
    public class HistoryViewFragment : Fragment
    {
        #region Components

        private View _view;
        private ListView _listview;
        private HistoryListAdapter _adapter;
        private ProgressBar _progressBar;
        public static HistoryItemViewModel ViewModel { get; set; }

        #endregion

        #region LifCycle

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
            ViewModel = new HistoryItemViewModel(new ServiceLocator().GetDatabaseHelper);

            _view = inflater.Inflate(Resource.Layout.history_page_layout, null);
            _listview = (ListView)_view.FindViewById(Resource.Id.history_list_view);
            _progressBar = (ProgressBar)_view.FindViewById(Resource.Id.loading_bar);
            _adapter = new HistoryListAdapter(Activity, ViewModel);
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
            _progressBar.Visibility = ViewStates.Visible;
            Handler h = new Handler();
            void myAction()
            {
                _progressBar.Visibility = ViewStates.Invisible;
            }
            h.PostDelayed(myAction, 100);
        }

        #endregion

        #region Methods

        #endregion
    }
}
