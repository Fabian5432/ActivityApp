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
        public ObservableCollection<ActivityModel> CountItems { get; }

        public Command LoadItemsCommand { get; set; }
        public Command LoadCountItemsCommand { get; set; }
        public Command AddItemCommand { get; set; }
        public Command AddCountItemsCommand { get; set; }

        public bool CanAddItem => !string.IsNullOrWhiteSpace(ActivityName);

        #endregion

        #region Constructor

        public ActivityItemsViewModel(IFirebaseDatabaseHelper firebaseDatabaseHelper)
        {
            _firebaseDatabaseHelper = firebaseDatabaseHelper;
            Items = new ObservableCollection<ActivityModel>();
            CountItems = new ObservableCollection<ActivityModel>();
            LoadItemsCommand = new Command(async () => await LoadItemsAsync());
            LoadCountItemsCommand = new Command(async () => await LoadCountItemsAsync());
            AddItemCommand = new Command<ActivityModel>(async (ActivityModel item) => await AddActivity(item));
            AddCountItemsCommand = new Command<ActivityModel>(async (ActivityModel item) => await AddCountActivity(item));
        }

        #endregion

        #region Methods 

        public async Task AddActivity(ActivityModel activity)
        {
            Items.Add(activity);
            await _firebaseDatabaseHelper.AddActivityToUser(activity);
        }

        public async Task AddCountActivity(ActivityModel activity)
        {
            CountItems.Add(activity);
            await _firebaseDatabaseHelper.AddActivityCountToUser(activity);
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

        public async Task LoadCountItemsAsync()
        {

            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                CountItems.Clear();
                var items = await _firebaseDatabaseHelper.GetAllCountActivites(true);
                foreach (var item in items)
                {
                    CountItems.Add(item);
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
