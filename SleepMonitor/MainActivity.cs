using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Microcharts;
using SkiaSharp;
using Microcharts.Droid;
using System.Collections.Generic;
using Android.Widget;
using SleepMonitor.ViewModel;
using Android.Bluetooth;
using System.Threading.Tasks;

namespace SleepMonitor
{
    [Activity(Label = "Dispozitiv Monitorizare", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private AccelerometerDataViewModel accelerometerData;
        private BluetoothConnectionViewModel bluetoothConnection;
        private BluetoothSocket _btSocket;
        ToggleButton _tgButton;
        TextView _resultTextView;
        Switch _switch;
        Switch _switch1;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            _tgButton = FindViewById<ToggleButton>(Resource.Id.toggleButton1);
            _resultTextView = FindViewById<TextView>(Resource.Id.textView1);
            _switch = FindViewById<Switch>(Resource.Id.switch1);
            _switch1 = FindViewById<Switch>(Resource.Id.switch2);

            _switch.CheckedChange += switch_state;
            _switch1.CheckedChange += switch_state2;
            _tgButton.CheckedChange += tgConnect_HandleCheckedChange;

            accelerometerData = ServiceViewModel.GetService<AccelerometerDataViewModel>() as AccelerometerDataViewModel;
            bluetoothConnection = ServiceViewModel.GetService<BluetoothConnectionViewModel>() as BluetoothConnectionViewModel;
           
        }

        public async void tgConnect_HandleCheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if (e.IsChecked)
            {   
               await accelerometerData.GetAccelerometerData();
          
                
            }
            else
            {
                _resultTextView.Text = string.Empty;

            }
            
        }
        public void switch_state(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            if(e.IsChecked)
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
            if(e.IsChecked)
            {   
                await accelerometerData.idAsync();
                await Task.Delay(1000);


            }
            else
            {
                _resultTextView.Text = string.Empty;
            }
        }

    }
}
