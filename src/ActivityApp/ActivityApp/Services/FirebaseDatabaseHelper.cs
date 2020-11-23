using ActivityApp.Models;
using ActivityApp.Services.Interfaces;
using Firebase.Database;
using Firebase.Database.Query;
using Plugin.Connectivity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ActivityApp.Services
{
    public class FirebaseDatabaseHelper : IFirebaseDatabaseHelper
    {
        #region Properties and Dependencies

        private readonly IFirebaseDatabaseConnection _firebaseDatabaseConnection;
        private readonly FirebaseClient _firebaseClient;
        private readonly string UserChild = "Users";
        private readonly string ActivityChild = "Activity";

        public List<ActivityModel> ActivityItems { get; set; }
        public List<ActivityModel> CountItems { get; set; }
        public List<UserModel> Users { get; set; }

        public FirebaseObject<UserModel> CurrentUser { get; set; }

        public FirebaseObject<ActivityModel> ActivityObj { get; set; }

        #endregion

        public FirebaseDatabaseHelper(IFirebaseDatabaseConnection firebaseDatabaseConnection)
        {
            _firebaseDatabaseConnection = firebaseDatabaseConnection;
            if (_firebaseClient == null)
                _firebaseClient = _firebaseDatabaseConnection.GetFirebaseClient();
            ActivityItems = new List<ActivityModel>();
            CountItems = new List<ActivityModel>();
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
            var token = await SecureStorage.GetAsync("userId");
            if (CrossConnectivity.Current.IsConnected)
            {
                CurrentUser = (await _firebaseClient.Child(UserChild).OnceAsync<UserModel>()).Where(user => user.Object.UserId == token)
                    .FirstOrDefault();
            }

            return CurrentUser;
        }
        public async Task<FirebaseObject<ActivityModel>> GetActivity(string name)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                ActivityObj = (await _firebaseClient.Child(UserChild).Child(ActivityChild).OnceAsync<ActivityModel>()).
                Where(a => a.Object.ActivityName == name).FirstOrDefault();
            }

            return ActivityObj;
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

        public async Task AddActivityCountToUser(ActivityModel activity)
        {
            var user = await GetCurrentUser();
            if (CrossConnectivity.Current.IsConnected)
            {
                await _firebaseClient.Child(UserChild).Child(user.Key).Child("Coffee consumption").PostAsync(activity);
            }
        }

        public async Task DeleteActivity(string activityName)
        {

            if (CrossConnectivity.Current.IsConnected)
            {
                var activity = (await _firebaseClient.Child(UserChild)
                    .Child(CurrentUser.Key)
                    .Child(ActivityChild)
                    .OnceAsync<ActivityModel>()).Where(a => a.Object.ActivityName == activityName).FirstOrDefault();
                await _firebaseClient.Child(UserChild).Child(CurrentUser.Key).Child(ActivityChild).Child(activity.Key).DeleteAsync();
            }

        }

        public async Task<List<ActivityModel>> GetAllUserActivities(bool forceRefresh = false)
        {
            var user = await GetCurrentUser();
            if (forceRefresh && CrossConnectivity.Current.IsConnected)
            {
                ActivityItems = (await _firebaseClient.Child(UserChild)
                    .Child(user.Key)
                    .Child(ActivityChild)
                    .OnceAsync<ActivityModel>()).Select(a => new ActivityModel(a.Object.ActivityName,
                                                                               a.Object.Date,
                                                                               a.Object.Time)).ToList();
            }

            return ActivityItems;
        }

        public async Task<List<ActivityModel>> GetAllCountActivites(bool forceRefresh)
        {
            var user = await GetCurrentUser();

            if (forceRefresh && CrossConnectivity.Current.IsConnected)
            {
                CountItems = (await _firebaseClient.Child(UserChild)
                                                   .Child(user.Key)
                                                   .Child("Coffee consumption")
                                                   .OnceAsync<ActivityModel>()).Select(a => new ActivityModel(a.Object.ActivityName, a.Object.Date, a.Object.Time)).ToList();
            }

            return CountItems;
        }
    }
}