using System.Collections.Generic;
using System.Threading.Tasks;
using SleepMonitor.Models;

namespace SleepMonitor.Services.Interfaces
{
    public interface IRepositoryService
    {
        Task<List<DeviceName>> GetAllPersons();
        Task<List<AccelerometerDataModel>> GetAllAccelerometerData();
        Task AddAccelerometerData();
        Task AddData();
        List<AccelerometerDataModel> ReadDataFromFile(string path);
    }
}