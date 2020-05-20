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
                Email = "Idea",
                Password = "3 items"
            });
            users.Add(new PersonModel()
            {
                Email = "Work",
                Password = "3 items"
            });
            users.Add(new PersonModel()
            {
                Email = "Food",
                Password = "4 items"
            });
            users.Add(new PersonModel()
            {
                Email = "Sport",
                Password = "2 items"
            });
            users.Add(new PersonModel()
            {
                Email = "Hobby",
                Password = "2 items"
            });
        }
    }
}