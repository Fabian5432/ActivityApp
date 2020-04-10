using App.Services.Interfaces;
using System.Threading.Tasks;
using ZXing.Mobile;

namespace App.Services
{
    class QrCodeService : IQrScanService
    {
        public async Task<string> ScanAsync()
        {
            var optionsCustom = new MobileBarcodeScanningOptions();

            var scanner = new MobileBarcodeScanner()
            {
                TopText = "Scan the QR Code",
                BottomText = "Please Wait",
            };

            var scanResult = await scanner.Scan(optionsCustom);
            return scanResult.Text;
        }
    }
}