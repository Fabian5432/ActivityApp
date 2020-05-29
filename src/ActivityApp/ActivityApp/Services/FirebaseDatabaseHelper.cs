using ActivityApp.Models;
using ActivityApp.Services.Interfaces;
using Firebase.Database;
using Firebase.Database.Query;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ActivityApp.Services
{
    public class FirebaseDatabaseHelper : IFirebaseDatabaseHelper
    {
        #region Fields

        private readonly FirebaseClient _firebaseClient;
        private readonly string UserChild = "Users";
        private readonly string ActivityChild = "Activity";
        List<ActivityModel> items;
        List<UserModel> users;
        FirebaseObject<UserModel> currentUser = null;

        #endregion

        public FirebaseDatabaseHelper(IFirebaseDatabaseConnection firebaseDatabaseConnection)
        { 
            if (_firebaseClient == null)
            _firebaseClient = firebaseDatabaseConnection.GetFirebaseClient();
            items = new List<ActivityModel>();
            users = new List<UserModel>();
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                users = (await _firebaseClient.Child(UserChild)
                               .OnceAsync<UserModel>()).Select(person => new UserModel
                               {
                                   UserId = person.Object.UserId,
                                   UserCredentials = person.Object.UserCredentials,
                                   UserStatus = person.Object.UserStatus
                               }).ToList();
            }
               
            return users;
        }

        public async Task<FirebaseObject<UserModel>> GetCurrentUser()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
              currentUser = (await _firebaseClient.Child(UserChild).OnceAsync<UserModel>()).
              Where(user => user.Object.UserId == GetSavedUserId()).FirstOrDefault();
            }

            return currentUser; 
        }

        public async Task AddUser(UserModel user)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                await _firebaseClient.Child(UserChild).PostAsync(user);
            }
                
        }

        public async Task DeleteUser()
        {
            var persontoDelete = await GetCurrentUser();
            if (CrossConnectivity.Current.IsConnected)
            {
                
                await _firebaseClient.Child(UserChild).Child(persontoDelete.Key).DeleteAsync();
            }    
        }

        public async Task AddActivityToUser(ActivityModel activity)
        {
            var user = await GetCurrentUser();
            if (CrossConnectivity.Current.IsConnected)
            {
                await _firebaseClient.Child(UserChild).Child(user.Key).Child(ActivityChild).PostAsync(activity);
            }
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

        public async Task<List<ActivityModel>> GetAllUserActivities(bool forceRefresh = false)
        {
            var user = await GetCurrentUser();
            if (forceRefresh && CrossConnectivity.Current.IsConnected)
            {
                items = (await _firebaseClient.Child(UserChild).Child(user.Key).Child(ActivityChild).OnceAsync<ActivityModel>()).Select(a => new ActivityModel()
                {
                    ActivityName = a.Object.ActivityName
                }).ToList();
            }

            return items;
        }

        public async Task UpdateUserLoginStatus(bool loginstatus)
        {
            var user = await GetCurrentUser();
            if (CrossConnectivity.Current.IsConnected)
            {
               await _firebaseClient.Child(UserChild).Child(user.Key).
               Child("UserStatus").Child("IsLoggedIn").
               PutAsync(loginstatus);
            }
        }
    }
}