using ActivityApp.Helper;
using ActivityApp.Models;
using ActivityApp.Services.Interfaces;
using Firebase.Auth;
using Plugin.Connectivity;
using System;
using System.Threading.Tasks;

namespace ActivityApp.Services
{
    public class LoginService : ILoginService
    {
        #region Properties and Dependencies 

        private readonly IFirebaseDatabaseHelper _firebaseDatabaseHelper;
        private readonly IFirebaseAuthProvider _firebaseAuthProvider;
        public event EventHandler LoggedOut;

        public FirebaseAuthLink Auth { get; set; }
      
        #endregion

        #region Constructor

        public LoginService(IFirebaseDatabaseHelper firebaseDatabaseHelper,
                            IFirebaseAuthProvider firebaseAuthProvider)
        {
            _firebaseAuthProvider = firebaseAuthProvider;
            _firebaseDatabaseHelper = firebaseDatabaseHelper;
        }

        #endregion

        #region Methods 

        public async Task Login(string email, string password)
        {
            try
            {   if(CrossConnectivity.Current.IsConnected.Equals(true))
                {
                    Auth = await _firebaseAuthProvider.SignInWithEmailAndPasswordAsync(email, password);
                    LocalData.RemoveToken();
                    LocalData.userToken = Auth.FirebaseToken;
                    LocalData.RemoveUserId();
                    LocalData.userId = Auth.User.LocalId;
                }
                else
                {
                    throw new Exception("Server is unavailable right now, try again later");
                }
            }
            catch(Exception e)
            {
                if(e.Message.Contains("INVALID_PASSWORD") || e.Message.Contains("EMAIL_NOT_FOUND"))
                {
                    throw new Exception("Your email or password are not valid", e);
                }
                else
                {   
                    throw new Exception(e.Message, e);
                }
            }
  
        }

        public void Logout()
        {
            LocalData.RemoveUserId();
            LoggedOut?.Invoke(this, EventArgs.Empty);
        }

        public async Task Register(string email, string password)
        {
            try
            {
                var auth = await _firebaseAuthProvider.CreateUserWithEmailAndPasswordAsync(email, password);
                LocalData.userToken = auth.FirebaseToken;
                var userCredentials = new UserCredentials() { Email = email};
                await _firebaseDatabaseHelper.AddUser(new UserModel()
                       {
                            UserId = auth.User.LocalId,
                            UserStatus = new UserStatus()
                            {
                                IsAdmin = false
                            },
                            UserCredentials = userCredentials
                        });
                LocalData.RemoveToken();
            }
            catch (Exception e)
            {
                if(e.Message.Contains("EMAIL_EXISTS"))
                {
                    throw new Exception("Email is already registerd");
                }
            }
        }

        public string GetCurrenUserEmail()
        {
            return _firebaseDatabaseHelper.CurrentUser.Object.UserCredentials.Email;
        }

        #endregion

    }
}