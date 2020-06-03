using FilmGrain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using FilmGrain.DTO;

namespace FilmGrain.Interfaces.DAL
{
    public interface IUserContext
    {
        void AddAccountToDB(UserDTO user);
        UserDTO GetAccountFromDB(string username, string password);
        string GetAccountName(string username);
    }
}
