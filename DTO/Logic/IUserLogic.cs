using System;
using System.Collections.Generic;
using System.Text;

namespace FilmGrain.Interfaces.Logic
{
    public interface IUserLogic
    {
        public void CreateAccount(UserDTO user);
        public UserDTO GetAccount(string username, string password);
        public bool Login(UserDTO user);
    }
}
