using System.Collections.Generic;
using System.Threading.Tasks;
using App.Models;

namespace App.Services.Interfaces
{
    public interface IRepositoryService
    {
        Task<List<User>> GetAllPersons();
        Task AddData(string email, string password, bool loggedin);
    }
}