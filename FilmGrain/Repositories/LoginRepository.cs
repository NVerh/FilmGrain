using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FilmGrain.Repositories
{
    public class LoginRepository : ILoginRepository
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
        public void RemoveLoginSession()
        {
            _contextAccessor.HttpContext.Session.Remove("Username");
            _contextAccessor.HttpContext.Session.Remove("Id");
        }
    }
}
