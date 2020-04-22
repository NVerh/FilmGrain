using System;
using DTO;
using FilmGrain.Interfaces.DAL;
using FilmGrain.Logic.Exceptions;
using FilmGrain.Interfaces.Logic;

namespace FilmGrain.Logic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserContext _userContext;

        public UserLogic(IUserContext userContext)
        {
            _userContext = userContext;
        }
        public void CreateAccount(UserDTO user)
        {
                if (CheckIfAccountAlreadyExists(user))
                {
                    _userContext.AddAccountToDB(user);
                }
            else
            {
                throw new UserLogicException(string.Format("User Already Exists!"));
            }
        }

        public UserDTO GetAccount(string username, string password)
        {
            return _userContext.GetAccountFromDB(username, password);
        }
        private bool CheckIfAccountAlreadyExists(UserDTO user)
        {
            return false;
        }
        private bool CheckIfAccountDataIsEmpty(UserDTO user)
        {
            if(user.Id <= 0)
            {
                return false;
            }
            return true;
        }
        private bool CheckIfAccountCredentialsAreCorrect(string username, string password)
        {
            return false;
        }
    }
}
