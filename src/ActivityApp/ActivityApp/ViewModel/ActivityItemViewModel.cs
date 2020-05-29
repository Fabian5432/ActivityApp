using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ActivityApp.Models;
using ActivityApp.Services.Interfaces;

namespace ActivityApp.ViewModel
{
    public class ActivityItemViewModel: BaseViewModel
    {
        #region Fields

        private IFirebaseDatabaseHelper _firebaseDatabaseHelper;

        #endregion

        #region Properties

        private string _activityName;
        public string ActivityName
        {
            get => _activityName;
            set
            {
                if (!Equals(_activityName, value))
                {
                    _activityName = value;
                    OnPropertyChanged(nameof(CanAddItem));
                }
            }
        }

        public ObservableCollection<ActivityModel> Items { get; set; }

        public bool CanAddItem => !string.IsNullOrWhiteSpace(ActivityName);

        #endregion

        #region Constructor

        public ActivityItemViewModel(IFirebaseDatabaseHelper firebaseDatabaseHelper)
        {
            _firebaseDatabaseHelper = firebaseDatabaseHelper;
            Items = new ObservableCollection<ActivityModel>();

        }

        #endregion

        #region Methods 

        public async Task AddActivity(ActivityModel activity)
        {
            Items.Add(activity);
            await _firebaseDatabaseHelper.AddActivityToUser(activity);
        }

        public async Task GetallActivity()
        {
            Items.Clear();
            var items = await _firebaseDatabaseHelper.GetAllUserActivities(true);
            foreach(var item in items)
            {
                Items.Add(item);
            }
        }

        #endregion

    }
}
