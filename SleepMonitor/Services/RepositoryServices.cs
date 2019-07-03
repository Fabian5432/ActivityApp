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
using Java.Util;
using Random = System.Random;

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

        //public async Task<List<AccelerometerDataModel>> GetAllAccelerometerData()
        //{
        //    //return (await _firebaseClient
        //    //       .Child("Accelerometer")
        //    //       .OnceAsync<AccelerometerDataModel>()).Select(accelerometer => new AccelerometerDataModel
        //    //       {
        //    //           BodyPosition = accelerometer.Object.BodyPosition,
        //    //           BodyMovement = accelerometer.Object.BodyMovement,
        //    //           XAxis = accelerometer.Object.XAxis,
        //    //           YAxis = accelerometer.Object.YAxis,
        //    //           ZAxis = accelerometer.Object.ZAxis
        //    //       }).ToList();
        //}

        public async Task AddPersonData(string firstname, string lastname)
        {
            await _firebaseClient
                                .Child("Person")
                                .PostAsync(new PersonModel() { Firstname = firstname, LastName = lastname });
        }

        public async Task AddAccelerometerData()
        {

            var documents = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var filename = Path.Combine(documents, "SleepMonitorData.txt");

            await _firebaseClient
             .Child("Accelerometer data")
             .PostAsync(ReadDataFromFile(filename));
                //new AccelerometerDataModel() {
                //     BodyMovement = random(0, 1),
                //     BodyPosition = random(0,5),
                //     XAxis = System.Math.Round(GetRandomAxis(0.00, 1.00), 2),
                //     YAxis = System.Math.Round(GetRandomAxis(0.00, 1.00), 2),
                //     ZAxis = System.Math.Round(GetRandomAxis(0.00, 1.00), 2)

                // });

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

        public int random(int min, int max)
        {
            Random r= new Random();
            return r.Next(min,max);
        }
        public double GetRandomAxis(double minimum, double maximum)
        {
            Random r = new Random();
            return r.NextDouble() * (maximum - minimum) + minimum;
        }
        #endregion

    }
}