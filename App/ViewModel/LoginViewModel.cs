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
                    //OnPropertyChanged(nameof(CanLogin));
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
                   // OnPropertyChanged(nameof(CanLogin));
                }
            }
        }

        public bool CanLogin => _loginService.IsUserloggedinAsync().Result && !string.IsNullOrWhiteSpace(Email) && !string.IsNullOrEmpty(Password);

        #endregion


        #region Constructor

        public LoginViewModel(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public async Task LoginAsync()
        {   
            try
            {   
                await _loginService.Login(Email, Password);
            }
            catch(Exception e)
            {
                throw new Exception("Login error", e);
            }
            finally 
            { 
                //OnPropertyChanged(nameof(CanLogin)); 
            }

        }
        #endregion
    }
}