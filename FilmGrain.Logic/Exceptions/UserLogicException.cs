using System;
using System.Collections.Generic;
using System.Text;

namespace FilmGrain.Logic.Exceptions
{
    public class UserLogicException : Exception
    {
        public UserLogicException(string message) : base(message)
        {

        }
    }
}
