
using Android.Widget;

namespace App.Models
{
    public class DeviceName
    {
        #region Constants

        private static int id = 0;

        #endregion

        public DeviceName()
        {
            PersonId = id++;
        }

        public int PersonId { get; set; }

        public string DevideName{get; set; }

        public string DeviceStateText { get; set; }

    }
}