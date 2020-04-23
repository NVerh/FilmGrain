using FilmGrain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmGrain.Interfaces.DAL
{
    interface IUserContext
    {
        void AddAccountToDB(UserDTO user);
        UserDTO GetAccountFromDB(string username, string password);
        string GetAccountName(string username);
    }
}
