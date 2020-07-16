using ActivityApp.Models;
using Firebase.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ActivityApp.Services.Interfaces
{
    public interface IFirebaseDatabaseHelper
    {
        public FirebaseObject<UserModel> CurrentUser { get; set; }
        public FirebaseObject<ActivityModel> ActivityObj { get; set; }

        Task<List<UserModel>> GetAllUsers();
        Task<FirebaseObject<UserModel>> GetCurrentUser();
        Task<FirebaseObject<ActivityModel>> GetActivity(string name);
        Task AddActivityToUser(ActivityModel activity);
        Task AddActivityCountToUser(ActivityModel activity);
        Task<List<ActivityModel>> GetAllUserActivities(bool forceRefresh);
        Task<List<ActivityModel>> GetAllCountActivites(bool forceRefresh);
        Task AddUser(UserModel person);
        Task DeleteUser();
        Task DeleteActivity(string activityName);
    }
}