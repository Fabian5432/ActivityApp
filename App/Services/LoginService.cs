using App.Models;
using App.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace App.Services
{
    public class LoginService : ILoginService
    {
        #region Fields

        private readonly IFirebaseDatabaseHelper _firebaseDatabaseHelper;
        public event EventHandler LoggedOut;
        public event EventHandler LoggedIn;
        public event EventHandler SignIn;

        #endregion

        #region Constructor

        public LoginService(IFirebaseDatabaseHelper firebaseDatabaseHelper)
        {
            _firebaseDatabaseHelper = firebaseDatabaseHelper;
        }

        #endregion

        #region Methods 

        public async Task Login(string email, string password)
        {
            try
            {   bool userFounded = false;
                var users = await _firebaseDatabaseHelper.GetAllUsers();
                var userCredentials = new UserCredentials() { Email =email, Password = password };

                if (!users.Equals(null) && users.Count!=0)
                {
                    foreach (var user in users)
                    {

                        if (user.UserCredentials.Email == userCredentials.Email && user.UserCredentials.Password == userCredentials.Password )
                        {   
                            _firebaseDatabaseHelper.SaveId(user.UserId);
                            userFounded = true;
                        }
                        continue;
                    }
                    if(userFounded==false)
                    {
                        throw new Exception("Your credentials are invalid!");
                    }
                }
                else
                {
                    throw new Exception("Your email or password are not vaild");
                }

            }
            catch(NullReferenceException e)
            {
                throw new NullReferenceException("User list is null", e);
            }
            LoggedIn?.Invoke(this, EventArgs.Empty);
        }

        public async Task<bool> IsUserloggedinAsync()
        {
            var user = await _firebaseDatabaseHelper.GetCurrentUser();

            if (user.Object.UserStatus.IsLoggedIn!=false)
                return true;
            else
                return false;
        }

        public async Task Logout()
        {
            LoggedOut?.Invoke(this, EventArgs.Empty);
        }
                                                                                                                                                                                           
        public async Task Register(string email, string password)
        {
            try
            {
                bool isUserRegistered = false; 
                var userCredentials = new UserCredentials() { Email = email, Password = password };
                var users = await _firebaseDatabaseHelper.GetAllUsers();
                if (users!=null && users.Count!=0)
                {
                    foreach (var user in users)
                    {
                        if (user?.UserCredentials?.Email == email)
                        {
                            isUserRegistered = true;
                            throw new Exception("User is already registered");
                        }
                        continue;
                    }
                    if (isUserRegistered == false)
                    {
                        await _firebaseDatabaseHelper.AddUser(new UserModel()
                        {
                            UserId = Guid.NewGuid(),
                            UserStatus = new UserStatus()
                            {
                                IsLoggedIn = false,
                                IsAdmin = false
                            },
                            UserCredentials = userCredentials
                        });
                    }
                }
            }
            catch (NullReferenceException e)
            {
                throw new NullReferenceException("Users list is null", e);
            }
            SignIn.Invoke(this, EventArgs.Empty);
        }

        #endregion

    }
}