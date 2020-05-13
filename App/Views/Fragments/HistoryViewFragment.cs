using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using App.Services;
using App.Views.Adapter;
using Fragment = Android.Support.V4.App.Fragment;

namespace App.Fragments
{
    public class HistoryViewFragment : Fragment
    {
        #region Components

        private View _view;
        private ListView _listview;
        private HistoryListAdapter _adapter;
        private Dialog _loading;

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
            _view = inflater.Inflate(Resource.Layout.history_page_layout, null);
            _listview = (ListView)_view.FindViewById(Resource.Id.history_list_view);
            _loading = new Dialog(Context);
            _loading.SetContentView(Resource.Layout.loading_view_layout);

            return _view;
        }

        public override void OnResume()
        {
            base.OnResume();

            _loading.Show();
            Handler h = new Handler();
            void myAction()
            {
                _adapter = new HistoryListAdapter(new HistoryData().Activity);
                _listview.Adapter = _adapter;
                _loading.Dismiss();
            }
            h.PostDelayed(myAction, 100);
        }

        #endregion

        #region MyRegion

        #endregion
    }
}
