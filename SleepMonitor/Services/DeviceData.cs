using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.Widget;
using Firebase.Database;
using App.Models;


namespace App.Services
{   
    public class DeviceData
    {  
        static FirebaseClient _firebaseClient = new FirebaseClient("https://proiectdiploma-ea2e5.firebaseio.com/");

        public List<DeviceName> Users { get; set; }

        public DeviceData()
        {
            var temp = new List<DeviceName>();
            AddData(temp);
            Users = temp.ToList();
        }

        string GetDeviceName()
        {
            return _firebaseClient
            .Child("Data").OnceSingleAsync<DeviceName>().Result.DevideName.ToString();
        }

        void AddData(List<DeviceName> users)
        {
            users.Add(new DeviceName()
            {   
                DevideName = "caca",
                DeviceStateText = "Coffe consumption"
            }); ;
        }
    }
}