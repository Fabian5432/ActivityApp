using System;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using App.Models;
using App.Views.ViewHolders;

namespace App.Views.Adapter
{
    public class HistoryListAdapter : BaseAdapter<ActivityModel>
    {
        readonly List<ActivityModel> _activity;

        public HistoryListAdapter(List<ActivityModel> activities)
        {
            _activity = activities;
        }

        public override ActivityModel this[int position]
        {
            get { return _activity[position]; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override int Count
        {
            get{ return _activity.Count;}
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            if (view == null)
            {
                view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.history_custom_item_layout, parent, false);
                var activity_date = view.FindViewById<TextView>(Resource.Id.date_id);
                var activity_time = view.FindViewById<TextView>(Resource.Id.clock_id);
                view.Tag = new HistoryListAdapterViewHolder() { ActivityDate = activity_date, ActivityTime = activity_time};
            }
            var holder = (HistoryListAdapterViewHolder)view.Tag;
            holder.ActivityDate.Text = _activity[position].Date;
            holder.ActivityTime.Text = _activity[position].Time;

            return view;
        }
    }
}