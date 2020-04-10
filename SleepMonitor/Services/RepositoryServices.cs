using System.Collections.Generic;
using System.Linq;
using App.Services.Interfaces;
using Firebase.Database;
using App.Models;
using System.Threading.Tasks;
using Firebase.Database.Query;

namespace App.Services
{
    public class RepositoryServices: IRepositoryService
    {
        #region Fields

        FirebaseClient _firebaseClient = new FirebaseClient("https://proiectdiploma-ea2e5.firebaseio.com/");

        #endregion

        #region Properties

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
                           .PostAsync(new DeviceName()
                           {
                               DevideName = "dada",
                               DeviceStateText="off"
                           });
        }
        #endregion

    }
}