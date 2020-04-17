using App.Models;
using System;
using System.Threading.Tasks;

namespace App.Services.Interfaces
{
    public interface ILoginService
    {
        Task Login(string email, string password, bool value);
        Task<bool> IsUserloggedinAsync();
    }
}