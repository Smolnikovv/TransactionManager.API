﻿using System.ComponentModel.DataAnnotations;

namespace TransactionManager.API.Models.User
{
    public class CreateUserDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
