using FilmGrain.DTO;
using FilmGrain.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Services
{
    public class UserMockRepository : IUserContext
    {
        List<UserDTO> users = new List<UserDTO>
        {
            new UserDTO { Id = 5, Email = "HenkSluipers@gmail.com", IsAdmin = false, UserName = "HenkS", Password = PasswordHash.Create("HenkisCool123",PasswordSalt.Create())},
            new UserDTO { Id = 7, Email = "TomTrapper@gmail.com", IsAdmin = false, UserName = "TomT", Password= PasswordHash.Create("TomTRock321", PasswordSalt.Create())},
            new UserDTO { Id = 9, Email = "NinoVerlopen@hotmail.com", IsAdmin = false, UserName = "NinoV", Password = PasswordHash.Create("NVer2321", PasswordSalt.Create())}
        };
        public void AddAccountToDB(UserDTO user)
        {
            users.Add(user);
        }

        public void Delete(UserDTO obj)
        {
            users.RemoveAt(obj.Id);
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

        public UserDTO Read(int key)
        {
            var user = users.Single(x => x.Id == key);
            return user;
        }

        public void Update(UserDTO obj)
        {
            throw new NotImplementedException();
        }

        void ICRUDContext<UserDTO>.Create(UserDTO obj)
        {
            users.Add(obj);
        }
    }
}
