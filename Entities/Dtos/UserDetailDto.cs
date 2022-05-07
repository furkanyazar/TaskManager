﻿using Core.Entities.Abstract;

namespace Entities.Dtos
{
    public class UserDetailDto : IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
    }
}
