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
        private readonly IUserDAL _userContext;

        public UserLogic(IUserDAL userContext)
        {
            _userContext = userContext;
        }

        public void AddAccountToDB(UserDTO user)
        {
            _userContext.AddAccountToDB(user);
        }

        public bool Create(UserDTO obj)
        {
            return _userContext.Create(obj);
        }

        public void CreateAccount(UserDTO user)
        {
            user.Password = PasswordHash.Create(user.Password, PasswordSalt.Create());
            _userContext.AddAccountToDB(user);
        }

        public bool Delete(UserDTO obj)
        {
            return _userContext.Delete(obj);
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
            return _userContext.GetAccountFromDB(username, password);
        }

        public string GetAccountName(string username)
        {
            return _userContext.GetAccountName(username);
        }

        public bool Login(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public UserDTO Read(int key)
        {
            return _userContext.Read(key);
        }

        public bool Update(UserDTO obj)
        {
           return _userContext.Update(obj);
        }
        public bool VerifyByEmail(string email)
        {
            try
            {
                if (_userContext.GetAccountByEmail(email) != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
