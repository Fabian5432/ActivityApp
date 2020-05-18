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
            Name = historyModel.Name;
            Date = historyModel.Date;
        }
    }
}
