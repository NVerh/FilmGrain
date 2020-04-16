using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interface
{
    interface IUserContext
    {
        void AddAccountToDB(UserDTO user);
    }
}
