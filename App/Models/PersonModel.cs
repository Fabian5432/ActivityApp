using System;
using System.Collections.Generic;

namespace App.Models
{
    public class PersonModel
    {  
        public Guid PersonId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email{ get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsLoggedIn { get; set; }

        public List<ActivityModel> Activity { get; set; }

    }
}