using ActivityApp.Models;
using ActivityApp.Services.Interfaces;
using Firebase.Auth;
using Plugin.Connectivity;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ActivityApp.Services
{
    public class LoginService : ILoginService
    {
        #region Properties and Dependencies 

        private readonly IFirebaseDatabaseHelper _firebaseDatabaseHelper;
        private readonly IFirebaseAuthProvider _firebaseAuthProvider;

        public event EventHandler LoggedOut;

        #endregion

        #region Constructor

        public LoginService(IFirebaseDatabaseHelper firebaseDatabaseHelper,
                            IFirebaseAuthProvider firebaseAuthProvider)
        {
            _firebaseAuthProvider = firebaseAuthProvider ?? throw new ArgumentNullException(nameof(firebaseAuthProvider));
            _firebaseDatabaseHelper = firebaseDatabaseHelper ?? throw new ArgumentNullException(nameof(firebaseDatabaseHelper));
        }

        #endregion

        #region Methods 

        public async Task LoginAsync(string email, string password)
        {
            try
            {
                if (CrossConnectivity.Current.IsConnected == true)
                {
                    var auth = await _firebaseAuthProvider.SignInWithEmailAndPasswordAsync(email, password);
                    await SecureStorage.SetAsync("token", auth.RefreshToken);
                    await SecureStorage.SetAsync("userId", auth.User.LocalId);
                }
                else
                {
                    throw new Exception("Server is unavailable right now, try again later");
                }
            }
            catch (Exception e)
            {
                if (e.Message.Contains("INVALID_PASSWORD") || e.Message.Contains("EMAIL_NOT_FOUND"))
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
            SecureStorage.Remove("userId");
            SecureStorage.Remove("token");
            LoggedOut?.Invoke(this, EventArgs.Empty);
        }

        public async Task RegisterAsync(string email, string password)
        {
            try
            {
                var auth = await _firebaseAuthProvider.CreateUserWithEmailAndPasswordAsync(email, password);
                var userCredentials = new UserCredentials() { Email = email };
                await _firebaseDatabaseHelper.AddUser(new UserModel()
                {
                    UserId = auth.User.LocalId,
                    UserStatus = new UserStatus()
                    {
                        IsAdmin = false
                    },
                    UserCredentials = userCredentials
                });
            }
            catch (Exception e)
            {
                if (e.Message.Contains("EMAIL_EXISTS"))
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