﻿using Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class User : IEntity
    {
        [Key]
        public int UserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool Status { get; set; } = true;
    }
}
