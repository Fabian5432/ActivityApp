
namespace ActivityApp.Models
{   
    public class ActivityModel 
    {
        public string ActivityName { get; }

        public ActivityModel(string ActivityName)
        {
            this.ActivityName = ActivityName;
        }
    }
}