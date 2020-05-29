using ActivityApp.Services.Interfaces;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ActivityApp.ViewModel
{
    public class LoginViewModel: BaseViewModel
    {
        #region Fields

        private readonly ILoginService _loginService;

        #endregion

        #region Properties

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                if (!Equals(_email, value))
                {
                    _email = value;
                    OnPropertyChanged(nameof(CanLogin));
                }
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                if(!Equals(_password,value))
                {
                    _password = value;
                    OnPropertyChanged(nameof(CanLogin));
                }
            }
        }
        private string _confirmedpassword;

        public string ConfirmedPassword
        {
            get => _confirmedpassword;
            set
            {
                if (!Equals(_confirmedpassword, value))
                {
                    _confirmedpassword = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }
        public bool CanLogin => !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password);

        public bool CanRegister => !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password) && !string.IsNullOrWhiteSpace(ConfirmedPassword);

        #endregion

        #region Constructor

        public LoginViewModel(ILoginService loginService)
        {
            _loginService = loginService;
        }

        #endregion

        #region Methods

        public async Task LoginAsync()
        {
            if (!CanLogin)
                return;

            try
            {
                await _loginService.Login(Email, Password);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
            finally
            {
                OnPropertyChanged(nameof(CanLogin));
            }

        }

        public async Task RegisterAync()
        {
            if (!CanRegister)
                return;
            try
            {   if (IsValidEmail(Email) && ConfirmedPassword.Equals(Password) && IsPasswordValid(Password))
                {
                    await _loginService.Register(Email, Password);
                }
                else
                {
                    throw new Exception("Credentials are not valid");
                }
            
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
            finally
            {
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        public async void Logout()
        {
            await _loginService.Logout();
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsPasswordValid(string password)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");

            var isValidated = hasNumber.IsMatch(password) && hasUpperChar.IsMatch(password) && hasMinimum8Chars.IsMatch(password);
            return isValidated;
        }
        #endregion



    }
}