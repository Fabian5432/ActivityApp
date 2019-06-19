using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SleepMonitor.Models;

namespace SleepMonitor.Services.Interfaces
{
    public interface IRepositoryService
    {
        Task<List<PersonModel>> GetAllPersons();
        Task<List<AccelerometerDataModel>> GetAllAccelerometerData();
    }
}