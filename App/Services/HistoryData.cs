using System;
using System.Collections.Generic;
using System.Linq;
using App.Models;

namespace App.Services
{
    public class HistoryData
    {
        public List<ActivityModel> Activity { get; set; }

        public HistoryData()
        {
            var temp = new List<ActivityModel>();
            AddData(temp);
            Activity = temp.ToList();
        }

        void AddData(List<ActivityModel> users)
        {
            users.Add(new ActivityModel()
            {
                ActivityName ="Meeting",
                Date = "12 Mar. 2020",
                Time = "13:30 PM"
            });
            users.Add(new ActivityModel()
            {
                ActivityName = "Coffee",
                Date = "12 Mar. 2020",
                Time = "13:30 PM"
            });
            users.Add(new ActivityModel()
            {
                ActivityName = "Meeting",
                Date = DateTime.Now.ToString("dd MMM. yyyy"),
                Time = DateTime.Now.ToString("h:mm tt")
            });
            users.Add(new ActivityModel()
            {
                ActivityName = "Coffee",
                Date = DateTime.Now.Month.ToString(),
                Time = "13:30 PM"
            });
            users.Add(new ActivityModel()
            {
                ActivityName = "Coffee",
                Date = "12 Mar. 2020",
                Time = "13:30 PM"
            });
            users.Add(new ActivityModel()
            {
                ActivityName = "Meeting",
                Date = "12 Mar. 2020",
                Time = "13:30 PM"
            });
            users.Add(new ActivityModel()
            {
                ActivityName = "Meeting",
                Date = "12 Mar 2020",
                Time = "13:30 PM"
            });
            users.Add(new ActivityModel()
            {
                ActivityName = "Meeting",
                Date = "12 Mar. 2020",
                Time = "13:30 PM"
            });
            users.Add(new ActivityModel()
            {
                ActivityName = "Meeting",
                Date = "12 Mar. 2020",
                Time = "13:30 PM"
            });
            users.Add(new ActivityModel()
            {
                ActivityName = "Meeting",
                Date = "12 Mar. 2020",
                Time = "13:30 PM"
            });
        }
    }
}