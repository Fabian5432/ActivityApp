using System.Threading.Tasks;

namespace ActivityApp.Services.Interfaces
{
    public interface IQrScanService
    {
        Task<string> ScanAsync();
    }
}