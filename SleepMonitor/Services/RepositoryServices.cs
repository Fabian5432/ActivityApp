using System.Collections.Generic;
using System.Linq;
using SleepMonitor.Services.Interfaces;
using Firebase.Database;
using SleepMonitor.Models;
using System.Threading.Tasks;
using System;
using System.IO;
using Firebase.Database.Query;

namespace SleepMonitor.Services
{
    public class RepositoryServices: IRepositoryService
    {
        #region Fields

        FirebaseClient _firebaseClient = new FirebaseClient("https://proiectdiploma-ea2e5.firebaseio.com/");

        #endregion

        #region Properties

        List<AccelerometerDataModel> AccelerometerData { get; set; }

        #endregion

        #region Methods

        public async Task<List<DeviceName>> GetAllPersons()
        {
            return (await _firebaseClient
                   .Child("Persons")
                   .OnceAsync<DeviceName>()).Select(person => new DeviceName
                   {
                       PersonId = person.Object.PersonId,
                       DevideName = person.Object.DevideName,
                       DeviceStateText = person.Object.DeviceStateText
                   }).ToList();
        }
        
        public async Task AddData()
        {
            await _firebaseClient
                       .Child("Data")
                           .PutAsync(new DeviceName()
                           {
                               DevideName = "dada",
                               DeviceStateText="off"
                           });
        }

        public async Task<List<AccelerometerDataModel>> GetAllAccelerometerData()
        {
            return (await _firebaseClient
                   .Child("Accelerometer data")
                   .OnceAsync<AccelerometerDataModel>()).Select(item => new AccelerometerDataModel
                   {
                       BPM = item.Object.BPM,
                       sleepTime=item.Object.sleepTime,
                       BodyPosition = item.Object.BodyPosition,
                       BodyMovement = item.Object.BodyMovement,
                       XAxis = item.Object.XAxis,
                       YAxis = item.Object.YAxis,
                       ZAxis = item.Object.ZAxis
                   }).ToList();
        }

        public async Task AddAccelerometerData()
        {

            var documents = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var filename = Path.Combine(documents, "SleepMonitorData.txt");

            await _firebaseClient
             .Child("Accelerometer data")
             .PostAsync(ReadDataFromFile(filename));
        }

        public List<AccelerometerDataModel> ReadDataFromFile(string path)
        {
            AccelerometerData = new List<AccelerometerDataModel>();

            using (var f = new StreamReader(path))
            {
                string line = string.Empty;
                while ((line = f.ReadLine()) != null)
                {
                    var parts = line.Split(",");
                    AccelerometerData.Add(new AccelerometerDataModel() {XAxis=Convert.ToDouble(parts[0]),});
                }

                f.Close();
            }
            return AccelerometerData;
        }
        #endregion

    }
}