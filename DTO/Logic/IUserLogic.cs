using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmGrain.Interfaces.Logic
{
    public interface IUserLogic
    {
        void CreateAccount(UserDTO user);
        UserDTO GetAccount(string password, string username);
    }
}
