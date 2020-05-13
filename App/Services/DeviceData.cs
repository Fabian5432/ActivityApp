using System.Collections.Generic;
using System.Linq;
using Firebase.Database;
using App.Models;

namespace App.Services
{
    public class DeviceData
    {  
        static readonly FirebaseClient _firebaseClient = new FirebaseClient("https://proiectdiploma-ea2e5.firebaseio.com/");

        public List<PersonModel> Users { get; set; }

        public DeviceData()
        {
            var temp = new List<PersonModel>();
            AddData(temp);
            Users = temp.ToList();
        }

        void AddData(List<PersonModel> users)
        {
            users.Add(new PersonModel()
            {
                Email = "Coffee",
                Password = "x2"
            });
            users.Add(new PersonModel()
            {
                Email = "Meetings",
                Password = "x2"
            });
        }
    }
}