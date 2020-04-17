using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using App.Services;
using System;
using ZXing.Mobile;
using Toolbar = Android.Widget.Toolbar;

namespace App.Activities
{
    [Activity(Label = "QrCodeActivity")]
    public class QrCodeActivity : AppCompatActivity
    {
        #region Components

        TextView _result;
        Button _scan_button;

        #endregion

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.qrcode_layout);
            MobileBarcodeScanner.Initialize(Application);
            _result = FindViewById<TextView>(Resource.Id.textResult);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            _scan_button = FindViewById<Button>(Resource.Id.scan);

            SetActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

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

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
                Finish();
            return base.OnOptionsItemSelected(item);
        }
    }
}