using App.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace App.ViewModel
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
                    OnPropertyChanged(nameof(isLoggedIn));
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
                    OnPropertyChanged(nameof(isLoggedIn));
                }
            }
        }

        public bool isLoggedIn => !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password);

        #endregion


        #region Constructor

        public LoginViewModel(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public async Task LoginAsync()
        {   
            if(!isLoggedIn)
                return;

            try
            {   
                await _loginService.Login(Email, Password);
            }
            catch(Exception e)
            {
                throw new Exception("Your email address or password are not valid", e);
            }
            finally 
            { 
                OnPropertyChanged(nameof(isLoggedIn)); 
            }

        }
        #endregion
    }
}