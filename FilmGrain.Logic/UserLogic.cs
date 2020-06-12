using System;
using FilmGrain.Interfaces.DAL;
using FilmGrain.Logic.Exceptions;
using FilmGrain.Interfaces;
using FilmGrain.Interfaces.Logic;
using FilmGrain.DTO;
using Services;

namespace FilmGrain.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserContext _userContext;

        public UserLogic(IUserContext userContext)
        {
            _userContext = userContext;
        }

        public void AddAccountToDB(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public void Create(UserDTO obj)
        {
            _userContext.Create(obj);
        }

        public void CreateAccount(UserDTO user)
        {
            user.Password = PasswordHash.Create(user.Password, PasswordSalt.Create());
            _userContext.AddAccountToDB(user);
        }

        public void Delete(UserDTO obj)
        {
            throw new NotImplementedException();
        }

        public UserDTO GetAccount(string username, string password)
        {
            throw new NotImplementedException();
        }
        public UserDTO GetAccountByEmail(string email)
        {
            return _userContext.GetAccountByEmail(email);
        }

        public UserDTO GetAccountFromDB(string username, string password)
        {
            throw new NotImplementedException();
        }

        public string GetAccountName(string username)
        {
            throw new NotImplementedException();
        }

        public bool Login(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public UserDTO Read(string key)
        {
            return _userContext.Read(key);
        }

        public void Update(UserDTO obj)
        {
            _userContext.Update(obj);
        }
    }
}
