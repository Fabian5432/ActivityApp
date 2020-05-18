using System;
namespace App.Models
{
    public class HistoryModel : ActivityModel
    {
        public string Name { get; set; }

        public string HistoryDate { get; set; }
        public string HistoryTime { get; set; }

        public HistoryModel()
        {
            Name = ActivityName;
        }
    }
}
