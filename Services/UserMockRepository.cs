using FilmGrain.DTO;
using FilmGrain.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class UserMockRepository : IUserContext
    {
        public UserDTO _user = new UserDTO { Id = 5, Email = "HenkSluipers@gmail.com", IsAdmin = false, UserName = "HenkS", Password = PasswordHash.Create("HenkisCool123",PasswordSalt.Create())};
        public void AddAccountToDB(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public string Create(UserDTO obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(UserDTO obj)
        {
            throw new NotImplementedException();
        }

        public UserDTO GetAccountByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public UserDTO GetAccountFromDB(string username, string password)
        {
            throw new NotImplementedException();
        }

        public string GetAccountName(string username)
        {
            throw new NotImplementedException();
        }

        public UserDTO Read(string key)
        {
            throw new NotImplementedException();
        }

        public void Update(UserDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
