using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using App.Models;
using App.Views.ViewHolders;

namespace App.Views.Adapter
{
    public class ActivityListAdapter : BaseAdapter<User>
    {
        List<User> _persons;

        public ActivityListAdapter(List<User> persons)
        {
            _persons = persons;
        }

        public override User this[int position]
        {
            get { return _persons[position]; }
        }

        public override int Count
        {
            get { return _persons.Count;  }
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
            holder.ActivityName.Text = _persons[position].Email;
            holder.ActivityValue.Text = _persons[position].Password;

            return view;
        }
    }
}
