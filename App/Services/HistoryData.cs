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
                Date = "12 Mar 2020",
                Time = "13:30 PM"
            });
            users.Add(new ActivityModel()
            {
                Date = "12 Mar 2020",
                Time = "13:30 PM"
            });
            users.Add(new ActivityModel()
            {
                Date = "12 Mar 2020",
                Time = "13:30 PM"
            });
            users.Add(new ActivityModel()
            {
                Date = "12 Mar 2020",
                Time = "13:30 PM"
            });
            users.Add(new ActivityModel()
            {
                Date = "12 Mar 2020",
                Time = "13:30 PM"
            });
            users.Add(new ActivityModel()
            {
                Date = "12 Mar 2020",
                Time = "13:30 PM"
            });
            users.Add(new ActivityModel()
            {
                Date = "12 Mar 2020",
                Time = "13:30 PM"
            });
        }
    }
}