using System.Threading.Tasks;

namespace App.Services.Interfaces
{
    public interface IQrScanService
    {
        Task<string> ScanAsync();
    }
}