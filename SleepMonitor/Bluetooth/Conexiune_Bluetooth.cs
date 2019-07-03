using System.Linq;
using Android.Bluetooth;

namespace SleepMonitor.Bluetooth
{
    public class Conexiune_Bluetooth
    {
        public BluetoothAdapter AdapterBluetooth { get; set; }
        public BluetoothDevice BluetoothDevice { get; set; }
        public BluetoothSocket SocketBluetooth { get; set; }

        public void getAdapter()
        {
            this.AdapterBluetooth = BluetoothAdapter.DefaultAdapter;
        }
        public void getDevise()
        {
            this.BluetoothDevice = (from bd in this.AdapterBluetooth.BondedDevices where bd.Name == "HC-05" select bd).FirstOrDefault();
        }

    }
}