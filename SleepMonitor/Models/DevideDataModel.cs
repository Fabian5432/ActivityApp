using System.ComponentModel;

namespace SleepMonitor.Models
{
    public class DeviceName : INotifyPropertyChanged
    {
        #region Constants

        public event PropertyChangedEventHandler PropertyChanged;
        private static int id = 0;

        #endregion

        public DeviceName()
        {
            PersonId = id++;
        }
        private string name;

        public int PersonId { get; set; }

        public string DevideName
        {
            get { return name; }

            set {
                name = value;
                OnPropertyChanged("DevideName");
            }
        }


        public string DeviceStateText { get; set; }
   
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}