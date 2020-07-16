
namespace ActivityApp.Models
{   
    public class ActivityModel 
    {
        public string ActivityName { get; }

        public string Date { get; }

        public string Time { get; }

        public ActivityModel(string ActivityName, string Date, string Time)
        {
            this.ActivityName = ActivityName;
            this.Date = Date;
            this.Time = Time;
        }
    }
}