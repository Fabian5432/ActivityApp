using Android.Widget;
using System;
using System.Collections.Generic;

namespace App.Models
{
    public class User
    {
        public Guid PersonId { get; set; }

        public string Username { get; set; }

        public string Email{get; set; }

        public string Password { get; set; }

        public bool Status { get; set; }

        public List<ActivityModel> Activity { get; set; }
    }
}