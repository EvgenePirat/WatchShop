﻿namespace WatchShop_UI.Dtos.Users.Request
{
    public class UpdateUserDto
    {
        public string? FullName { get; set; }

        public string UserName { get; set; }

        public string? Email { get; set; }

        public string? City { get; set; }

        public string Role { get; set; }
    }
}
