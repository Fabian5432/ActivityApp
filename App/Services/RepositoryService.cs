using App.Services.Interfaces;
using System;
using App.Models;
using System.Threading.Tasks;

namespace App.Services
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
       
        public async Task AddActivityAsync(ActivityModel activity)
        {
           
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