using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Microcharts;
using SkiaSharp;
using Microcharts.Droid;
using System.Collections.Generic;

namespace SleepMonitor
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        // TimePicker timerPicker;
        List<Entry> entries = new List<Entry>
        {
            new Entry(200)
            {
                Color=SKColor.Parse("#FF1943"),
                Label ="January",
                ValueLabel = "200"
            },
            new Entry(400)
            {
                Color = SKColor.Parse("00BFFF"),
                Label = "March",
                ValueLabel = "400"
            },
            new Entry(-100)
            {
                Color =  SKColor.Parse("#00CED1"),
                Label = "Octobar",
                ValueLabel = "-100"
            },
            };
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            var chartView = FindViewById<ChartView>(Resource.Id.chartView);

            var chart = new LineChart() { Entries = entries };
            chartView.Chart = chart;
        }
    }
}