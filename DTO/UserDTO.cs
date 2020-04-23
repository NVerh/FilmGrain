using System;

namespace FilmGrain.Interfaces
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public string Email { get; set; }
    }
}
