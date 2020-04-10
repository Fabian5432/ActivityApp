using Android.App;
using Android.OS;
using Android.Widget;
using App.Services;
using System;
using ZXing.Mobile;

namespace App.Activities
{
    [Activity(Label = "QrCodeActivity")]
    public class QrCodeActivity : Activity
    {
        TextView _result;
        Button _scan_button;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.qrcode_layout);

            MobileBarcodeScanner.Initialize(Application);
            _result = FindViewById<TextView>(Resource.Id.textResult);
            _scan_button = FindViewById<Button>(Resource.Id.scan);
     
        }

        protected override void OnResume()
        {
            base.OnResume();
            _scan_button.Click += btn_click;
        }

        protected override void OnPause()
        {
            base.OnPause();
            _scan_button.Click -= btn_click;
        }

        private async void btn_click(object sender, EventArgs e)
        {
            try
            {
                var scanner = ServiceLocator.GetQrScanService;
                var result = await scanner.ScanAsync();
                if (result != null)
                    _result.Text = result;
                return;

            }
            catch (Exception ex)
            { 
                Console.WriteLine("Error", ex.Message);
            }
        }
    }
}