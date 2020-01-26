using System;
using System.IO;
using Android.Bluetooth;
using Firebase.Database;
using SleepMonitor.Bluetooth;
using SleepMonitor.Services.Interfaces;
using Firebase.Database.Query;
using System.Threading.Tasks;
using SleepMonitor.Models;

namespace SleepMonitor.Services
{
    public class ConnectivityService : IConnectivityService
    {
        private FirebaseClient _firebaseClient = new FirebaseClient("https://proiectdiploma-ea2e5.firebaseio.com/");

        private Conexiune_Bluetooth _conexiuneBluetooth;
        private BluetoothSocket _btSocket;
        private Stream _outStream;
        private Stream _inStream;

        public void BluetoothConnect()
        {
            try
            {
                _conexiuneBluetooth = new Conexiune_Bluetooth();
                _conexiuneBluetooth.getAdapter();
                _conexiuneBluetooth.AdapterBluetooth.StartDiscovery();
                _conexiuneBluetooth.getDevise();
                _conexiuneBluetooth.BluetoothDevice.SetPairingConfirmation(true);
                _conexiuneBluetooth.BluetoothDevice.CreateBond();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error getting device", e.Message);

            }

            try
            {
                _conexiuneBluetooth.AdapterBluetooth.CancelDiscovery();
                _btSocket = _conexiuneBluetooth.BluetoothDevice.CreateInsecureRfcommSocketToServiceRecord(Java.Util.UUID.FromString("00001101-0000-1000-8000-00805f9b34fb"));
                _conexiuneBluetooth.SocketBluetooth = _btSocket;
                _conexiuneBluetooth.SocketBluetooth.Connect();

            }
            catch (Exception e)
            {
                Console.WriteLine("Lost connection" + e.Message);
                try
                {
                    _conexiuneBluetooth.SocketBluetooth.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error" + ex.Message);
                }
            }
        }


        public async Task ListenForData()
        {
            while (_btSocket.IsConnected)
            {
                try
                {
                    _inStream = _btSocket.InputStream;
                    using (var str = new StreamReader(_inStream))
                    {

                        var line = str.ReadLine();
                        if (line.EndsWith(";"))
                        {
                            var parts = line.Split(",");
                            await _firebaseClient
                                .Child("Accelerometer data")
                                    .PutAsync(new AccelerometerDataModel()
                                    {
                                        BodyPosition = Convert.ToInt32(parts[0]),
                                        XAxis = Convert.ToDouble(parts[1]),
                                        YAxis = Convert.ToDouble(parts[2]),
                                        ZAxis = Convert.ToDouble(parts[3])

                                    });

                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);

                }

            }
        }

        public void BluetoothWriteData(Java.Lang.String data)
        {
            try
            {
                _outStream = _btSocket.OutputStream;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e.Message);
            }
            Java.Lang.String message = data;
            byte[] msgBuffer = message.GetBytes();

            try
            {
                _outStream.Write(msgBuffer, 0, msgBuffer.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e.Message);
            }
        }
        public void Disconnected()
        {
            try
            {
                if (_btSocket.IsConnected)
                {
                    _btSocket.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Connection can't be closed", e.Message);
            }

        }
    }
}


