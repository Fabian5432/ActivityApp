using System;
using App.Models;

namespace App.ViewModel
{
    public class HistoryViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

        public HistoryViewModel() { }

        public HistoryViewModel(HistoryModel historyModel)
        {
            Name = historyModel.ActivityName;
            Date = historyModel.Date;
            Time = historyModel.Time;
        }
    }
}
