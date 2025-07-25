﻿using System.ComponentModel.DataAnnotations;

namespace ClientLibrary.Models.Authentication
{
    public class CreateUser : AuthenticationBase
    {
        [Required]
        public string? Fullname { get; set; }
        [Required, Compare(nameof(Password))]
        public string? ConfirmPassword { get; set; }
    }
}
