using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmGrain.Models.User;
using FilmGrain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Services;
using FilmGrain.Logic;

namespace FilmGrain.Controllers
{
    public class AccountController : Controller
    {
        private readonly LoginRepository _loginRepo;
        private readonly PasswordHash _hash;
        private readonly PasswordSalt _salt;
        private readonly UserLogic _userLogic;
        

        public AccountController(LoginRepository loginRepo, PasswordHash hash, PasswordSalt salt, UserLogic userLogic )
        {
            _loginRepo = loginRepo;
            _hash = hash;
            _salt = salt;
            _userLogic = userLogic;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(AccountViewModel account)
        {

            return View();
        }
        public IActionResult Register(RegisterViewModel account)
        {
            if(ModelState.IsValid)
            {
                _loginRepo.SetLoginSession(account.Username, account.Id);
            }
            return View();
        }
    }
}