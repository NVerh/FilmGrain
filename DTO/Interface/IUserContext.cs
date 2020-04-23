using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmGrain.Interfaces
{
    public interface IUserContext
    {
        void AddAccountToDB(UserDTO user);
        UserDTO GetAccountFromDB(string username, string password);
        string GetAccountName(string username);
    }
}
