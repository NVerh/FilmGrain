﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FilmGrain.Repositories
{
    public  class LoginRepository
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public LoginRepository()
        {

        }
        public LoginRepository(IHttpContextAccessor contextAccessor)
        {
            this._contextAccessor = contextAccessor;
        }
        public void SetLoginSession(string username, int id)
        {
            _contextAccessor.HttpContext.Session.SetString("Username", username);
            _contextAccessor.HttpContext.Session.SetInt32("Id", id);
        }
        public string GetUsername()
        {
            return _contextAccessor.HttpContext.Session.GetString("Username");
        }
        public void RemoveLoginSession()
        {
            _contextAccessor.HttpContext.Session.Remove("Username");
            _contextAccessor.HttpContext.Session.Remove("Id");
        }
        public int GetUserId()
        {
            return (int)_contextAccessor.HttpContext.Session.GetInt32("Id");
        }
    }
}
