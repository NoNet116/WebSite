﻿namespace WebSite.Models
{
    public class UserViewModel
    {
        public required string LastName { get; set; }
        public required string FirstName { get; set; }
        public string? FatherName { get; set; }
        public required string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public required string UserName { get; set; }
    }
}
