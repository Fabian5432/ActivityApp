using System;
using App.Models;

namespace App.ViewModel
{
    public class ActivityViewModel: BaseViewModel
    {
        public string ActivityName { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public ActivityViewModel() { }

        public ActivityViewModel(ActivityModel activityModel)
        {
            ActivityName = activityModel.ActivityName;
        }
    }
}
