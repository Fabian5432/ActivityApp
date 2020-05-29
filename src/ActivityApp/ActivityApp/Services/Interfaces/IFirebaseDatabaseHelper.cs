using ActivityApp.Models;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ActivityApp.Services.Interfaces
{
    public interface IFirebaseDatabaseHelper
    {
        Task<List<UserModel>> GetAllUsers();
        Task<FirebaseObject<UserModel>> GetCurrentUser();
        Task AddActivityToUser(ActivityModel activity);
        Task<List<ActivityModel>> GetAllUserActivities(bool forceRefresh);
        Task AddUser(UserModel person);
        Task UpdateUserLoginStatus(bool loginStatus);
        Task DeleteUser();

        void SaveId(Guid id);
    }
}