using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Entry = Microcharts.Entry;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microcharts;
using Microcharts.Droid;
using SkiaSharp;
using SleepMonitor.ViewModel;
using System.Threading.Tasks;

namespace SleepMonitor
{
    [Activity(Label = "Chart", MainLauncher = true)]
    public class Chart : Activity
    {
        private AccelerometerDataViewModel accelerometerData;
        private List<Entry> _entries;
        private ChartView ChartValues;

        public int ValueLabel { get; private set; }

        private SKColor Color;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            accelerometerData = ServiceViewModel.GetService<AccelerometerDataViewModel>() as AccelerometerDataViewModel;
            // Create your application here
            SetContentView(Resource.Layout.chart);

            ChartValues = FindViewById<ChartView>(Resource.Id.Chart2);

            var chart = new BarChart { Entries =  GetEntries().Result};
            ChartValues.Chart = chart;
        }

        public async Task<List<Entry>> GetEntries()
        {
            var data = await accelerometerData.GetData();

            Random rnd = new Random();
            string[] colors = { "#CCCC00", "#660000", "#006600", "#0066FF", "#000000", "#330099", "#993399", "#009999", "#FF0000" };

            _entries = new List<Entry>();
            foreach (var item in data)
            {
                _entries.Add(new Entry(float.Parse(item.BodyMovement.ToString()))
                {
                    Label = "",
                    ValueLabel = item.BodyPosition.ToString(),
                    Color = SKColor.Parse(colors[rnd.Next(0, colors.Length)]),

                });
            }

            return _entries;
        }
       
    }
}