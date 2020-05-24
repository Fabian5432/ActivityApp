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
            {
                var users = await _firebaseDatabaseHelper.GetAllUsers();
                if (users.Equals(null) && users.Count!=0)
                {
                    foreach (var user in users)
                    {
                        var userCredentials = new UserCredentials() { Email = user.UserCredentials.Email, Password = user.UserCredentials.Password };
                        if (userCredentials.Email == email && userCredentials.Password == password)
                        {   
                            _firebaseDatabaseHelper.SaveId(user.UserId);
                        }
                        else
                        {
                            throw new Exception("Email or password are incorrect");
                        }
                    }
                }
                else
                {
                    throw new Exception("Your email or password are not vaild");
                }

            }
            catch(NullReferenceException e)
            {
                throw new NullReferenceException("UserModel is null", e);
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
                var userCredentials = new UserCredentials() { Email = email, Password = password };
                var users = await _firebaseDatabaseHelper.GetAllUsers();
                if (users!=null && users.Count!=0)
                    foreach (var user in users)
                    {
                        if (user?.UserCredentials?.Email != email)
                        {
                            await _firebaseDatabaseHelper.AddUser(new UserModel() {
                                UserId =  Guid.NewGuid(),
                                UserStatus=new UserStatus() {
                                    IsLoggedIn = false,
                                    IsAdmin = false},
                                UserCredentials = userCredentials });
                        }
                        else
                        {
                            throw new Exception("Email is already in use");
                        }
                    }
                else
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
            catch (NullReferenceException e)
            {
                throw new NullReferenceException("", e);
            }
        }

        #endregion

    }
}