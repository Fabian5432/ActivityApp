using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SleepMonitor.Models
{
    public class PersonModel
    {
        #region Constants

        private static int id = 0;

        #endregion

        public PersonModel()
        {
            PersonId = id++;
        }

        public int PersonId { get; set; }

        public string Firstname { get; set; }

        public string LastName { get; set; }

    }
}