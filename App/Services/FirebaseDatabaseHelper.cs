using App.Models;
using App.Services.Interfaces;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services
{
    public class FirebaseDatabaseHelper : IFirebaseDatabaseHelper
    {
        #region Fields

        private readonly FirebaseClient _firebaseClient;
        private readonly string UserChild = "Users";

        #endregion

        public FirebaseDatabaseHelper(IFirebaseDatabaseConnection firebaseDatabaseConnection)
        { 
            if (_firebaseClient == null)
            _firebaseClient = firebaseDatabaseConnection.GetFirebaseClient();
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            return (await _firebaseClient.Child(UserChild)
                .OnceAsync<UserModel>()).Select(person => new UserModel
                {
                    UserId = person.Object.UserId,
                    UserCredentials = person.Object.UserCredentials,
                    UserStatus = person.Object.UserStatus
                }).ToList();
        }

        public async Task<FirebaseObject<UserModel>> GetCurrentUser()
        {
            return (await _firebaseClient.Child(UserChild).OnceAsync<UserModel>()).
                Where(user => user.Object.UserId == GetSavedUserId()).FirstOrDefault();
        }

        public async Task AddUser(UserModel user)
        {
           await _firebaseClient.Child(UserChild).PostAsync(user);
        }

        public async Task DeleteUser()
        {
            var persontoDelete = await GetCurrentUser();
            await _firebaseClient.Child(UserChild).Child(persontoDelete.Key).DeleteAsync();
        }

        public async Task AddActivityToUser(ActivityModel activity)
        {
            var user = await GetCurrentUser();
            await _firebaseClient.Child(UserChild).Child(user.Key).Child("Activity").PostAsync(activity);
        }

        public void SaveId(Guid id)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string settingsPath = Path.Combine(path, "userid.txt");
            StreamWriter stream = File.CreateText(settingsPath);
            stream.WriteLine(id);
            stream.Close();
        }

        public Guid GetSavedUserId()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string settingsPath = Path.Combine(path, "userid.txt");
            string idfromfile = File.ReadAllText(settingsPath);

            return Guid.Parse(idfromfile);
        }


    }
}