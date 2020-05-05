using System.Collections.Generic;
using System.Linq;
using Firebase.Database;
using App.Models;

namespace App.Services
{
    public class DeviceData
    {  
        static readonly FirebaseClient _firebaseClient = new FirebaseClient("https://proiectdiploma-ea2e5.firebaseio.com/");

        public List<User> Users { get; set; }

        public DeviceData()
        {
            var temp = new List<User>();
            AddData(temp);
            Users = temp.ToList();
        }

        void AddData(List<User> users)
        {
            users.Add(new User()
            {
                Email = "Coffee",
                Password = "x2"
            });
            users.Add(new User()
            {
                Email = "Meetings",
                Password = "x2"
            });
        }
    }
}