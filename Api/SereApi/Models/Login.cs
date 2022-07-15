using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SereApi.Models
{
    public partial class Login
    { 
        public string? EmailPerson { get; set; }

        public string? PasswordPerson { get; set; }
    }
}