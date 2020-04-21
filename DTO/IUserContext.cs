using System;
using System.Collections.Generic;
using System.Text;
using FilmGrain.Interfaces;

namespace FilmGrain.Interfaces.Interfaces
{
    public interface IUserContext
    {
        void AddAccountToDB(UserDTO user);
        UserDTO GetAccountFromDB(string username, string password);
        string GetAccountName(string username);
    }
}
