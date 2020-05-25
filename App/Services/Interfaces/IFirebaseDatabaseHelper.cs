using App.Models;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Services.Interfaces
{
    public interface IFirebaseDatabaseHelper
    {
        Task<List<UserModel>> GetAllUsers();
        Task<FirebaseObject<UserModel>> GetCurrentUser();
        Task AddActivityToUser(ActivityModel activity);
        Task AddUser(UserModel person);
        Task DeleteUser();

        void SaveId(Guid id);
    }
}