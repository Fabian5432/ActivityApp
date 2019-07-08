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
        public int BPM { get; set; }

        public double XAxis { get; set; }

        public double YAxis { get; set; }

        public double ZAxis { get; set; }

        public int BodyPosition { get; set; }

        public int BodyMovement { get; set; }

        public DateTime sleepTime { get; set; }

        public AccelerometerDataModel()
        {

        }
    }
}