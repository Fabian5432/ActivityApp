using ActivityApp.Models;
using ActivityApp.ViewModel;
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

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);
            SetContentView(Resource.Layout.activity_item_details);

            var data = Intent.GetStringExtra("data");
            var item = Newtonsoft.Json.JsonConvert.DeserializeObject<ActivityModel>(data);
            ViewModel = new ActivityItemDetailsViewModel(item);

            SupportActionBar.Title = ViewModel.Item.ActivityName;
        }

        protected override void OnStart()
        {
            base.OnStart();
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
