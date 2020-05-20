using System;
using System.Collections.Generic;
using System.Linq;
using App.Models;
using Firebase.Database;
using Firebase.Database.Query;

namespace App.Services
{
    public class HistoryData
    {
        FirebaseClient _firebaseClient = new FirebaseClient("https://proiectdiploma-ea2e5.firebaseio.com/");

        public List<HistoryModel> Activity { get; set; }

        
        public HistoryData()
        {
            var temp = new List<HistoryModel>();
            additem(temp);
            Activity = temp.ToList();
        }

        public List<HistoryModel> GetAllActivity()
        {  
            PersonModel result = _firebaseClient
                   .Child("User")
                   .Child("-M57RIoDRvKV7fEbbtnJ").OnceSingleAsync<PersonModel>().Result;
            return result.Activity.OrderBy(e=>DateTime.Parse(e.Date).Date.Month).ThenBy(e=>DateTime.Parse(e.Date).Date.Year).ToList();
        }
        void additem(List<HistoryModel> activity)
        {
            foreach(var i in GetAllActivity())
            {
                activity.Insert(0, i);
            }
        }
    }
}