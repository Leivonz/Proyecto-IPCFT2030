using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SereApi.Models
{
    public class Login
    {
        public string EmailPerson { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}