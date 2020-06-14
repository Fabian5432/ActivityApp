using ActivityApp.Helper;
using ActivityApp.Models;
using ActivityApp.Services.Interfaces;
using Firebase.Database;
using Firebase.Database.Query;
using Plugin.Connectivity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActivityApp.Services
{
    public class FirebaseDatabaseHelper : IFirebaseDatabaseHelper
    {
        #region Properties and Dependencies

        private readonly IFirebaseDatabaseConnection _firebaseDatabaseConnection;
        private readonly FirebaseClient _firebaseClient;
        private readonly string UserChild = "Users";
        private readonly string ActivityChild = "Activity";

        public List<ActivityModel> Items { get; set; }
        public List<UserModel> Users { get; set; }

        public FirebaseObject<UserModel> CurrentUser { get; set; }

        #endregion

        public FirebaseDatabaseHelper(IFirebaseDatabaseConnection firebaseDatabaseConnection)
        {
            _firebaseDatabaseConnection = firebaseDatabaseConnection;
            if (_firebaseClient == null)
                _firebaseClient = _firebaseDatabaseConnection.GetFirebaseClient();
            Items = new List<ActivityModel>();
            Users = new List<UserModel>();
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                Users = (await _firebaseClient.Child(UserChild)
                               .OnceAsync<UserModel>()).Select(person => new UserModel
                               {
                                   UserId = person.Object.UserId,
                                   UserCredentials = person.Object.UserCredentials,
                                   UserStatus = person.Object.UserStatus
                               }).ToList();
            }
               
            return Users;
        }

        public async Task<FirebaseObject<UserModel>> GetCurrentUser()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
              CurrentUser = (await _firebaseClient.Child(UserChild).OnceAsync<UserModel>()).
              Where(user => user.Object.UserId == UserLocalData.userId).FirstOrDefault();
            }

            return CurrentUser; 
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

        public async Task<List<ActivityModel>> GetAllUserActivities(bool forceRefresh = false)
        {
            var user = await GetCurrentUser();
            if (forceRefresh && CrossConnectivity.Current.IsConnected)
            {
                Items = (await _firebaseClient.Child(UserChild).Child(user.Key).Child(ActivityChild).OnceAsync<ActivityModel>()).Select(a => new ActivityModel()
                {
                    ActivityName = a.Object.ActivityName
                }).ToList();
            }

            return Items;
        }
    }
}