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
using Java.Lang;

namespace SleepMonitor.Models
{
    public class AccelerometerDataModel
    {
     
        public int XAxis { get; set; }

        public int YAxis { get; set; }

        public int ZAxis { get; set; }

        public int BodyPosition { get; set; }

        public int BodyMovement { get; set; }
    }
}