using System;
using DAL.Interface;
using DTO;
using FilmGrain.Logic.Exceptions;

namespace FilmGrain.Logic
{
    public class UserLogic
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
