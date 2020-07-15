using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using ActivityApp.Models;
using ActivityApp.Services.Interfaces;

namespace ActivityApp.ViewModel
{
    public class ActivityItemsViewModel: BaseViewModel
    {
        #region Properties and Dependencies

        private IFirebaseDatabaseHelper _firebaseDatabaseHelper;

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

        public ObservableCollection<ActivityModel> Items { get; }

        public Command LoadItemsCommand { get; set; }
        public Command AddItemCommand { get; set; }

        public bool CanAddItem => !string.IsNullOrWhiteSpace(ActivityName);

        #endregion

        #region Constructor

        public ActivityItemsViewModel(IFirebaseDatabaseHelper firebaseDatabaseHelper)
        {
            _firebaseDatabaseHelper = firebaseDatabaseHelper;
            Items = new ObservableCollection<ActivityModel>();
            LoadItemsCommand = new Command(async () => await LoadItemsAsync());
            AddItemCommand = new Command<ActivityModel>(async (ActivityModel item) => await AddActivity(item));
        }

        #endregion

        #region Methods 

        public async Task AddActivity(ActivityModel activity)
        {
            Items.Add(activity);
            await _firebaseDatabaseHelper.AddActivityToUser(activity);
        }

        public async Task LoadItemsAsync()
        {
            
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await _firebaseDatabaseHelper.GetAllUserActivities(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        #endregion

    }
}
