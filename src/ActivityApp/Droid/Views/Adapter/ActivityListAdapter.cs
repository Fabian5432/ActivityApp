using ActivityApp.Models;
using ActivityApp.ViewModel;
using Android.App;
using Android.Views;
using Android.Widget;
using ActivityApp.Views.ViewHolders;

namespace ActivityApp.Views.Adapter
{
    public class ActivityListAdapter : BaseAdapter<ActivityModel>
    {

        ActivityItemViewModel activityViewModel;
        Activity activity;

        public ActivityListAdapter(Activity activity, ActivityItemViewModel activityViewModel)
        {
            this.activity = activity;
            this.activityViewModel = activityViewModel;

            this.activityViewModel.Items.CollectionChanged += (sender, args) =>
            {
                this.activity.RunOnUiThread(NotifyDataSetChanged);
            };

        }

        public override ActivityModel this[int position]
        {
            get { return activityViewModel.Items[position]; }
        }

        public override int Count
        {
            get { return activityViewModel.Items.Count;  }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            if(view==null)
            {
                view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.custom_activity_layout, parent, false);
                var activity_name = view.FindViewById<TextView>(Resource.Id.activity_title_id);
                var activity_value = view.FindViewById<TextView>(Resource.Id.activity_value_id);
                view.Tag = new ActivityListAdapterViewHolder() { ActivityName = activity_name, ActivityValue = activity_value};
            }
            var holder = (ActivityListAdapterViewHolder)view.Tag;
            holder.ActivityName.Text = activityViewModel.Items[position].ActivityName;

            return view;
        }
    }
}
