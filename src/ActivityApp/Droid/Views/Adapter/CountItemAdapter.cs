using System;
using ActivityApp.ViewModel;
using Android.App;
using Android.Views;
using Android.Widget;
using ActivityApp.Views.ViewHolders;
using ActivityApp.Models;

namespace ActivityApp.Views.Adapter
    {
        public class CountItemAdapter : BaseAdapter<ActivityModel>
        {

            ActivityItemsViewModel activityViewModel;
            Activity activity;

            public CountItemAdapter(Activity activity, ActivityItemsViewModel activityViewModel)
            {
                this.activity = activity;
                this.activityViewModel = activityViewModel;

                this.activityViewModel.CountItems.CollectionChanged += (sender, args) =>
                {
                    this.activity.RunOnUiThread(NotifyDataSetChanged);
                };

            }

            public override ActivityModel this[int position]
            {
                get { return activityViewModel.CountItems[position]; }
            }

            public override int Count
            {
                get { return activityViewModel.CountItems.Count; }
            }

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
            holder.ActivityType.Text = activityViewModel.CountItems[position].ActivityName;
            holder.ActivityDate.Text = activityViewModel.CountItems[position].Date;
            holder.ActivityTime.Text = activityViewModel.CountItems[position].Time;

            return view;
        }
        }
    }

