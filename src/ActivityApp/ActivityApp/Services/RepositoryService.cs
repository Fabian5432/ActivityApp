using System;
using System.Threading.Tasks;
using ActivityApp.Services.Interfaces;
using ActivityApp.Models;

namespace ActivityApp.Services
{
    public class RepositoryService : IRepositoryService
    {
        #region Fields
        readonly IFirebaseDatabaseHelper _firebaseDatabaseHelper;

        #endregion

        #region Properties

        #endregion

        #region Constructor

        public RepositoryService(IFirebaseDatabaseHelper firebaseDatabaseHelper)
        {
            _firebaseDatabaseHelper = firebaseDatabaseHelper;
        }

        #endregion

        #region Methods
       
        public async Task AddActivityAsync(string activityname)
        {
            var activity = new ActivityModel() { ActivityName = activityname };
            await  _firebaseDatabaseHelper.AddActivityToUser(activity);
        }

        #region Encryption Method

        public string Hash(string value)
        {
            var bytes = new System.Text.UTF8Encoding().GetBytes(value);
            var hashBytes = System.Security.Cryptography.MD5.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }

        #endregion

        #endregion

    }
}