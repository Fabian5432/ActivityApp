using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using SleepMonitor.Models;


namespace SleepMonitor.Services
{
    public static class DeviceData
    {  
        static FirebaseClient _firebaseClient = new FirebaseClient("https://proiectdiploma-ea2e5.firebaseio.com/");

        public static  List<DeviceName> Users { get; private set; }

        static DeviceData()
        {
            var temp = new List<DeviceName>();

            AddData(temp);

            Users = temp.OrderBy(i => i.DevideName).ToList();
        }

        static string GetDeviceName()
        {
            return _firebaseClient
            .Child("Data").OnceSingleAsync<DeviceName>().Result.DevideName.ToString();
        }

        static void AddData(List<DeviceName> users)
        {  
            users.Add(new DeviceName()
            {
                DevideName=GetDeviceName(),
                DeviceStateText= "dadad"
            });
        }
    }
}