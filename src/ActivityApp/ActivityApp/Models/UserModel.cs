using System;

namespace ActivityApp.Models
{
    public class UserModel
    {
        public string UserId { get; set; }

        public UserCredentials UserCredentials { get; set; }

        public UserStatus UserStatus { get; set; }

    }
}