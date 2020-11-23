using System;
using ActivityApp.Models;
using ActivityApp.ViewModel.Base;

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
