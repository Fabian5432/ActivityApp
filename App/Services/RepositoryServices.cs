using System.Collections.Generic;
using System.Linq;
using App.Services.Interfaces;
using Firebase.Database;
using App.Models;
using System.Threading.Tasks;
using Firebase.Database.Query;
using System;

namespace App.Services
{
    public class RepositoryServices : IRepositoryService
    {
        #region Fields

        private readonly FirebaseClient _firebaseClient;
        private readonly string Child = "User";

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

        public async Task<List<PersonModel>> GetAllPersons()
        {
            return (await _firebaseClient
                   .Child("Persons")
                   .OnceAsync<PersonModel>()).Select(person => new PersonModel
                   {
                       PersonId = person.Object.PersonId,
                       FirstName = person.Object.FirstName,
                       LastName = person.Object.LastName,
                       Email = person.Object.Email,
                       Password = person.Object.Password,
                       IsAdmin = person.Object.IsAdmin,
                       IsLoggedIn = person.Object.IsLoggedIn,
                       Activity = person.Object.Activity,

                   }).ToList();
        }

        public async Task AddPerson(PersonModel person)
        {
            if (_firebaseClient.Equals(null))
                return;
            try
            {
                await _firebaseClient
                       .Child(Child)
                       .PostAsync(person);
            }
            catch (Exception e)
            {
                throw new Exception("Firebase client exception", e);
            }
        }

        public async Task<PersonModel> GetPerson(Guid id)
        {   
            var persons = await GetAllPersons();
            await _firebaseClient.Child(Child).
                OnceAsync<PersonModel>();
            return persons.Where(person => person.PersonId == id).FirstOrDefault();
        }
        
        #endregion

    }
}