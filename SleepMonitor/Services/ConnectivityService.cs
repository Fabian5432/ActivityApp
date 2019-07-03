using System;
using System.Collections.Generic;
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
        private Conexiune_Bluetooth _conexiuneBluetooth;
        private BluetoothSocket _btSocket;
        private Stream _outStream = null;
        private Stream _inStream = null;
        private string valor;
        private string _data;
        
        

        FirebaseClient _firebaseClient = new FirebaseClient("https://proiectdiploma-ea2e5.firebaseio.com/");

        public void BluetoothConnect()
        {
            _conexiuneBluetooth = new Conexiune_Bluetooth();
            _conexiuneBluetooth.getAdapter();
            _conexiuneBluetooth.AdapterBluetooth.StartDiscovery();
            try
            {
                _conexiuneBluetooth.getDevise();
                _conexiuneBluetooth.BluetoothDevice.SetPairingConfirmation(true);
                _conexiuneBluetooth.BluetoothDevice.CreateBond();
            }
            catch (System.Exception e)
            {

            }

            _conexiuneBluetooth.AdapterBluetooth.CancelDiscovery();
            _btSocket = _conexiuneBluetooth.BluetoothDevice.CreateInsecureRfcommSocketToServiceRecord(Java.Util.UUID.FromString("00001101-0000-1000-8000-00805f9b34fb"));
            _conexiuneBluetooth.SocketBluetooth = _btSocket;

            try
            {
                _conexiuneBluetooth.SocketBluetooth.Connect();

            }
            catch (System.Exception e)
            {
                System.Console.WriteLine("Lost connection" + e.Message);
                try
                {
                    _conexiuneBluetooth.SocketBluetooth.Close();
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine("Error" + e.Message);
                }
            }
        }
       

        public async Task ListenForData()
        {
            
           var documents = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
           var filename = Path.Combine(documents, "SleepMonitorData.txt");
            while (_btSocket.IsConnected)
            {
                try
                    {
                        _inStream = _btSocket.InputStream;
                        using (var str = new StreamReader(_inStream))
                        {
                            var line = str.ReadLine();
                        if(line.EndsWith(";"))
                        {
                            var parts= line.Split(",");
                            await _firebaseClient
                                .Child("Accelerometer data")
                                    .PostAsync(new AccelerometerDataModel() { BodyPosition=Convert.ToInt32(parts[0])});

                            continue;
                        }
                        else
                        {
                            break;
                        }
                        }
                    }
                    catch (System.IO.IOException e)
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
            catch (System.Exception e)
            {
                System.Console.WriteLine("Error" + e.Message);
            }
            Java.Lang.String message = data;
            byte[] msgBuffer = message.GetBytes();

            try
            {
                _outStream.Write(msgBuffer, 0, msgBuffer.Length);
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine("Error" + e.Message);
            }
        }
        public void Disconnected()
        {
            if (_btSocket.IsConnected)
            {
                try
                {
                    _btSocket.Close();
                }
                catch (Exception e)
                {

                }
            }
        }

    }
}

