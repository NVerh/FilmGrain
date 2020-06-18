using FilmGrain.DTO;
using FilmGrain.Interfaces.DAL;
using FilmGrain.Interfaces.Mock;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace FilmGrain.DAL.Mock
{
    public class UserMockRepository : IUserMock
    {
        public static List<UserDTO> users = new List<UserDTO>
        {
            new UserDTO { Id = 1, Email = "Hs@gmail.com", IsAdmin = false, UserName = "HS", Password = "HS2"},
            new UserDTO { Id = 2, Email = "To@gmail.com", IsAdmin = false, UserName = "T", Password= "Tomk321"},
            new UserDTO { Id = 3, Email = "Ni@hotmail.com", IsAdmin = false, UserName = "N", Password = "NV1" },
            new UserDTO { Id = 4, Email = "HenkSluipers@gmail.com", IsAdmin = false, UserName = "HenkS", Password ="HenkisCool123"},
            new UserDTO { Id = 5, Email = "TomTrapper@gmail.com", IsAdmin = false, UserName = "TomT", Password= "Test123"},
            new UserDTO { Id = 6, Email = "NinoVerlopen@hotmail.com", IsAdmin = false, UserName = "NinoV", Password = "NVer2321"}
        };
        public void AddAccountToDB(UserDTO user)
        {
            users.Add(user);
        }

        public bool Delete(UserDTO obj)
        {
            users.RemoveAt(obj.Id);
            if(!users.Contains(obj) && obj.Id != 0)
            {
                return true;
            }
            return false;
        }

        public UserDTO GetAccount(string username, string password)
        {
            throw new NotImplementedException();
        }

        public UserDTO GetAccountByEmail(string email)
        {
            var user = users.Single(em => em.Email == email);
            return user;
        }

        public UserDTO GetAccountFromDB(string username, string password)
        {
            var user = users.Where(un => un.UserName == username && un.Password == password).Single();
            return user;
        }

        public string GetAccountName(string username)
        {
            string _username = users.Single(x => x.UserName == username).UserName;
            return _username;
        }

        public bool Login(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public UserDTO Read(int key)
        {
            var user = users.Single(x => x.Id == key);
            return user;
        }

        public bool Update(UserDTO obj)
        {
            throw new NotImplementedException();
        }
         bool ICRUDDAL<UserDTO>.Create(UserDTO obj)
        {
            users.Add(obj);
            if (users.Contains(obj))
            {
                return true;
            }
            return false;
        }
    }
}
