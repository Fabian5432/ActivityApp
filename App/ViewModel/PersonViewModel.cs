using System;
using App.Models;

namespace App.ViewModel
{
    public class PersonViewModel : BaseViewModel
    {
        #region Fields

        public Guid PersonId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsLoggedIn { get; set; }

        #endregion

        #region Constructor
        public PersonViewModel() { }

        public PersonViewModel(PersonModel personModel)
        {
            _firstName = personModel.FirstName;
            _lastName = personModel.LastName;
            PersonId = personModel.PersonId;
            Email = personModel.Email;
            Password = personModel.Password;
            IsAdmin = personModel.IsAdmin;
            IsLoggedIn = personModel.IsLoggedIn;
        }

        #endregion

        #region Properties

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                SetProperty(ref _firstName, value);
                OnPropertyChanged(nameof(FullName));
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }

            set
            {
                SetProperty(ref _lastName, value);
                OnPropertyChanged(nameof(FullName));
            }
        }

        public string FullName { get { return $"{ FirstName} { LastName}"; } }

        #endregion

    }
}