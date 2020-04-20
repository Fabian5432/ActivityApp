using System.Collections.Generic;
using System.Linq;
using App.Services.Interfaces;
using Firebase.Database;
using App.Models;
using System.Threading.Tasks;
using Firebase.Database.Query;
using System;
using System.IO;

namespace App.Services
{
    public class RepositoryServices: IRepositoryService
    {
        #region Fields

        private readonly FirebaseClient _firebaseClient; 
        #endregion

        #region Properties

        #endregion

        #region Constructor

        public RepositoryServices()
        {
            _firebaseClient = new FirebaseClient("https://proiectdiploma-ea2e5.firebaseio.com/");
        }

        #endregion

        #region Methods

        public async Task<List<User>> GetAllPersons()
        {
            return (await _firebaseClient
                   .Child("Persons")
                   .OnceAsync<User>()).Select(person => new User
                   {
                       PersonId = person.Object.PersonId,
                       Email = person.Object.Email,
                       Password = person.Object.Password,
                       Activity = person.Object.Activity
                   }).ToList();
        }

        public async Task AddData(string email, string password, bool loggedin)
        {
            var id = Guid.NewGuid();
                await _firebaseClient
                            .Child("User")
                            .PostAsync(new User()
                            {   PersonId = id,
                                Email = email,
                                Password = Hash(password), 
                                Status = loggedin,
                                Activity = new List<ActivityModel>()
                                {
                                    new ActivityModel(){ ActivityName="Coffe", Date="12 Mar. 2020", Time= "1:30 PM"}
                                }
                               
                             });
        }

        public string Hash(string password)
        {
            var bytes = new System.Text.UTF8Encoding().GetBytes(password);
            var hashBytes = System.Security.Cryptography.MD5.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }

        #endregion

    }
}