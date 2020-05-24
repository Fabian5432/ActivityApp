using System;
using System.Collections.Generic;

namespace App.Models
{
    public class UserModel
    {
        public Guid UserId { get; set; }

        public UserCredentials UserCredentials { get; set; }

        public UserStatus UserStatus { get; set; }

    }
}