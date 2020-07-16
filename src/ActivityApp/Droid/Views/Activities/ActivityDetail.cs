using ActivityApp.Models;
using ActivityApp.Services;
using ActivityApp.ViewModel;
using ActivityApp.Views.Adapter;
using ActivityApp.Views.Fragments;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace ActivityApp.Droid
{
    [Activity(ParentActivity = typeof(MainPageViewFragment))]
    public class ActivityDetail : AppCompatActivity
    {
        private ActivityItemDetailsViewModel ViewModel;
        public static ActivityItemsViewModel Data { get; set; }
        private ListView _itemList;
        private CountItemAdapter _adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
            SetContentView(Resource.Layout.activity_item_details);
            _itemList = (ListView)FindViewById(Resource.Id.item_list);
           
          
            var data = Intent.GetStringExtra("data");
            var item = Newtonsoft.Json.JsonConvert.DeserializeObject<ActivityModel>(data);
            ViewModel = new ActivityItemDetailsViewModel(item);
            Data = new ActivityItemsViewModel(new ServiceLocator().GetDatabaseHelper);
            _adapter = new CountItemAdapter(this, Data);

            SupportActionBar.Title = ViewModel.Item.ActivityName;

            if(item.ActivityName == "Coffee consumption")
            {
                _itemList.Adapter = _adapter;
            }
        }

        protected override void OnStart()
        {
            base.OnStart();
            if(Data.CountItems.Count == 0)
                Data.LoadCountItemsCommand.Execute(null);
        }

        protected override void OnStop()
        {
            base.OnStop();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
                Finish();
            return base.OnOptionsItemSelected(item);
        }

        
    }
}
