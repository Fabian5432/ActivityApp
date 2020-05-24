using System;
using System.Drawing.Printing;

namespace App.Models
{
    public class HistoryModel
    {  
        public ActivityModel Activity { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }
}
