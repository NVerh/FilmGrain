using System;
using DAL.Interface;
using DTO;

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
            _userContext.AddAccountToDB(user);
        }
        public void CheckIfAccountAlreadyExists(UserDTO user)
        {

        }    
    }
}
