using System;
using System.Threading.Tasks;
using ActivityApp.Services.Interfaces;
using ActivityApp.Models;

namespace ActivityApp.Services
{
    public class RepositoryService : IRepositoryService
    {
        #region Properties and Dependencies

        readonly IFirebaseDatabaseHelper _firebaseDatabaseHelper;

        #endregion

        #region Constructor

        public RepositoryService(IFirebaseDatabaseHelper firebaseDatabaseHelper)
        {
            _firebaseDatabaseHelper = firebaseDatabaseHelper;
        }

        #endregion

    }
}