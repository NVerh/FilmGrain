using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interface
{
    public interface IUserContext
    {
        void AddAccountToDB(UserDTO user);
    }
}
