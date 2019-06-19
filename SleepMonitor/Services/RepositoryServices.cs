using System.Collections.Generic;
using System.Linq;
using SleepMonitor.Services.Interfaces;
using Firebase.Database;
using SleepMonitor.Models;
using System.Threading.Tasks;
using System;
using System.IO;
using Firebase.Database.Query;
using Java.Lang;

namespace SleepMonitor.Services
{
    public class RepositoryServices: IRepositoryService
    {
        #region Fields

        FirebaseClient _firebaseClient = new FirebaseClient("https://proiectdiploma-ea2e5.firebaseio.com/");

        #endregion

        #region Properties

        AccelerometerDataModel data { get; set; }

        List <PersonModel> Persons { get; set; }

        List<AccelerometerDataModel> AccelerometerData { get; set; }

        #endregion

        #region Methods

        public async Task<List<PersonModel>> GetAllPersons()
        {
            return (await _firebaseClient
                   .Child("Persons")
                   .OnceAsync<PersonModel>()).Select(person => new PersonModel
                   {
                       PersonId = person.Object.PersonId,
                       Firstname = person.Object.Firstname,
                       LastName = person.Object.LastName
                   }).ToList();
        }

        public async Task<List<AccelerometerDataModel>> GetAllAccelerometerData()
        {
            return (await _firebaseClient
                   .Child("Accelerometer")
                   .OnceAsync<AccelerometerDataModel>()).Select(accelerometer => new AccelerometerDataModel
                   {
                       BodyPosition = accelerometer.Object.BodyPosition,
                       BodyMovement = accelerometer.Object.BodyMovement,
                       XAxis = accelerometer.Object.XAxis,
                       YAxis = accelerometer.Object.YAxis,
                       ZAxis = accelerometer.Object.ZAxis
                   }).ToList();
        }

        public async Task AddPersonData(string firstname, string lastname)
        {
            await _firebaseClient
                                .Child("Person")
                                .PostAsync(new PersonModel() { Firstname = firstname, LastName = lastname });
        }

        public async Task AddAccelerometerData()
        {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var filename = Path.Combine(documents, "SleepMonitorData.txt");
            var text = File.ReadAllText(filename);
            var line = text.Split(',');
        
            await _firebaseClient
                                 .Child("Accelerometer data")
                                 .PostAsync(new AccelerometerDataModel()
                                 {
                                     BodyPosition = Integer.ParseInt(line[0]),
                                     BodyMovement = Integer.ParseInt(line[1]),
                                     XAxis = Integer.ParseInt(line[2]),
                                     YAxis = Integer.ParseInt(line[3]),
                                     ZAxis = Integer.ParseInt(line[4])
                                 });
        }

        public async Task StoreDataToFile()
        {
            var lines = string.Format("{0},{1},{2},{3},{4}", data.XAxis, data.YAxis, data.ZAxis, data.BodyPosition, data.BodyMovement);
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var filename = Path.Combine(documents, "SleepMonitorData.txt");
            File.WriteAllText(filename,lines);
        }
       

        #endregion

    }
}