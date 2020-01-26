using Android.OS;
using Android.Views;
using Android.Widget;
using SleepMonitor.ViewModel;
using System.Threading.Tasks;

namespace SleepMonitor.Fragments
{
    public class SettingViewfragment : Android.Support.V4.App.Fragment
    {
        private AccelerometerDataViewModel accelerometerData;
        private BluetoothConnectionViewModel bluetoothConnection;
        private View _view;
        private Switch _switch1;
        private Switch _switch2;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your fragment here
            accelerometerData = ServiceViewModel.GetService<AccelerometerDataViewModel>() as AccelerometerDataViewModel;
            bluetoothConnection = ServiceViewModel.GetService<BluetoothConnectionViewModel>() as BluetoothConnectionViewModel;
        }

        public static SettingViewfragment NewInstance()
        {
            var setting_fragment = new SettingViewfragment { Arguments = new Bundle() };
            return setting_fragment;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            _view = inflater.Inflate(Resource.Layout.setting_page_layout, null);
            _switch1 = (Switch)_view.FindViewById(Resource.Id.switch1);
            _switch2 = (Switch)_view.FindViewById(Resource.Id.switch2);
            return _view;
        }

        public override void OnResume()
        {
            base.OnResume();
            _switch1.CheckedChange += switch_state;
            _switch2.CheckedChange += switch_state2;
        } 

        public override void OnPause()
        {
            base.OnPause();
            _switch1.CheckedChange -= switch_state;
            _switch2.CheckedChange -= switch_state2;
        }

        public void switch_state(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if (e.IsChecked)
            {
                bluetoothConnection.BluetoothConnect();

            }
            else
            {
                bluetoothConnection.BluetoothDisconnect();
            }
        }

        public async void switch_state2(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if (e.IsChecked)
            {
                await Task.Delay(1000);
                await accelerometerData.AddAccelerometerData();
            }
            else
            {

            }
        }

    }
}
