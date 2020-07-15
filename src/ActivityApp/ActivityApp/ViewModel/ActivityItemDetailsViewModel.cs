using System;
using ActivityApp.Models;

namespace ActivityApp.ViewModel
{
    public class ActivityItemDetailsViewModel : BaseViewModel
    {
        public ActivityModel Item { get; }

        public ActivityItemDetailsViewModel(ActivityModel Item = null)
        {
            if (Item != null)
                this.Item = Item ?? throw new ArgumentNullException(nameof(Item));

        }
    }
}
