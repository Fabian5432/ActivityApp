using ActivityApp.Models;
using Android.Views;
using Android.Widget;
using ActivityApp.Views.ViewHolders;
using ActivityApp.ViewModel;
using Android.App;

namespace ActivityApp.Views.Adapter
{
    public class HistoryListAdapter : BaseAdapter<ActivityModel>
    {
        HistoryItemViewModel historyItemViewModel;
        Activity activity;

        public HistoryListAdapter(Activity activity, HistoryItemViewModel historyItemViewModel)
        {
            this.activity = activity;
            this.historyItemViewModel = historyItemViewModel;

            this.historyItemViewModel.Items.CollectionChanged += (sender, args) =>
            {
                this.activity.RunOnUiThread(NotifyDataSetChanged);
            };

        }

        public override ActivityModel this[int position]
        {
            get { return historyItemViewModel.Items[position]; }
        }

        public override int Count { get { return historyItemViewModel.Items.Count; } }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            if (view == null)
            {
                view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.history_custom_item_layout, parent, false);
                var activity_type = view.FindViewById<TextView>(Resource.Id.activity_type_id);
                var activity_date = view.FindViewById<TextView>(Resource.Id.date_id);
                var activity_time = view.FindViewById<TextView>(Resource.Id.clock_id);
                view.Tag = new HistoryListAdapterViewHolder()
                {
                    ActivityType = activity_type,
                    ActivityDate = activity_date,
                    ActivityTime = activity_time
                };
            }
            var holder = (HistoryListAdapterViewHolder)view.Tag;
            holder.ActivityType.Text = historyItemViewModel.Items[position].ActivityName;
            holder.ActivityDate.Text = historyItemViewModel.Items[position].Date;
            holder.ActivityTime.Text = historyItemViewModel.Items[position].Time;

            return view;
        }
    }
 }