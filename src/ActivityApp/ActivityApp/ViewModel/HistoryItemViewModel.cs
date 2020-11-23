using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using ActivityApp.Models;
using ActivityApp.Services.Interfaces;
using ActivityApp.ViewModel.Base;

namespace ActivityApp.ViewModel
{
    public class HistoryItemViewModel : BaseViewModel
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

        private Command _loadItemsCommand;
        public ICommand LoadItemsCommand
        {
            get => _loadItemsCommand ??= new Command(async () => await LoadHistoryItemsAsync());
        }


        public bool CanAddItem => !string.IsNullOrWhiteSpace(ActivityName);

        #endregion

        #region Constructor

        public HistoryItemViewModel(IFirebaseDatabaseHelper firebaseDatabaseHelper)
        {
            _firebaseDatabaseHelper = firebaseDatabaseHelper;
            Items = new ObservableCollection<ActivityModel>();
            LoadItemsCommand.Execute(null);
        }

        #endregion

        #region Methods 

        public async Task LoadHistoryItemsAsync()
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