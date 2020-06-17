﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FilmGrain.DTO
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public ProfileViewModel Profile { get; set; }
    }
}