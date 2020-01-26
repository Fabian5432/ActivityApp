using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using SleepMonitor.Models;
using SleepMonitor.Views.ViewHolders;

namespace SleepMonitor.Adapter
{
    public class CustomListAdapter : BaseAdapter<DeviceName>
    {
        List<DeviceName> _persons;

        public CustomListAdapter(List<DeviceName> persons)
        {
            this._persons = persons;
        }

        public override DeviceName this[int position]
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
                view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.device_layout, parent, false);
                var device_text = view.FindViewById<TextView>(Resource.Id.deviceTextView);
                var device_name = view.FindViewById<TextView>(Resource.Id.deviceNameView);
                view.Tag = new ViewHolder() { DeviceName = device_name, DeviceText = device_text };
            }
            var holder = (ViewHolder)view.Tag;
            holder.DeviceName.Text = _persons[position].DevideName;
            holder.DeviceText.Text = _persons[position].DeviceStateText;

            return view;
        }
    }
}
