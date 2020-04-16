using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmGrain.Models.User;
using FilmGrain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FilmGrain.Controllers
{
    public class AccountController : Controller
    {
        private readonly LoginRepository _loginRepo;

        public AccountController(LoginRepository loginRepo)
        {
            _loginRepo = loginRepo;
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
    }
}