using App.Models;
using App.Services.Interfaces;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services
{
    public class LoginService : ILoginService
    {
        #region Fields

        private readonly FirebaseClient _firebaseClient;
        private static readonly string child = "User";

        #endregion

        #region Constructor

        public LoginService()
        {
            _firebaseClient= new FirebaseClient("https://proiectdiploma-ea2e5.firebaseio.com/");
        }

        #endregion

        #region Methods 

        private async Task<FirebaseObject<User>> GetCurrentUserbyId(Guid id)
        {
            return (await _firebaseClient
                            .Child(child)
                            .OnceAsync<User>()).FirstOrDefault(a => a.Object.PersonId == id);
        }

        private async Task<FirebaseObject<User>> GetUserByEmail(string email)
        {
            return (await _firebaseClient
                  .Child(child)
                  .OnceAsync<User>()).FirstOrDefault(a => a.Object.Email == email);
        }

        public async Task Login(string email, string password, bool value)
        {
            var user = await GetUserByEmail(email);

            if (user?.Object.Email == email && user?.Object.Password == Hash(password))
            {  
               await _firebaseClient
                    .Child(child)
                    .Child(user.Key)
                    .Child("Status")
                    .PutAsync(value);
                Savecurrentuserid(user.Object.PersonId);
            }
            else
            {
                return;
            }
        }

        public async Task<bool> IsUserloggedinAsync()
        {   
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string settingsPath = Path.Combine(path, "userid.txt");
            string idfromfile = File.ReadAllText(settingsPath);

            var currentUserid = await GetCurrentUserbyId(Guid.Parse(idfromfile));
            var isUserloggedin = _firebaseClient
                   .Child(child)
                   .Child(currentUserid.Key).OnceSingleAsync<User>().Result.Status;

            if (isUserloggedin!=false)
                return true;
            else
                return false;
        }

        private void Savecurrentuserid(Guid id)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string settingsPath = Path.Combine(path, "userid.txt");
            StreamWriter stream = File.CreateText(settingsPath);
            stream.WriteLine(id);
            stream.Close();
        }

        public string Hash(string password)
        {
            var bytes = new System.Text.UTF8Encoding().GetBytes(password);
            var hashBytes = System.Security.Cryptography.MD5.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }
        #endregion

    }
}