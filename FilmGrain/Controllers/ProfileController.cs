using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmGrain.Models.User;
using FilmGrain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmGrain.Controllers
{
    public class ProfileController : Controller
    {
        private readonly LoginRepository _loginRepo;
        public ProfileController(LoginRepository loginRepo)
        {
            _loginRepo = loginRepo;
        }
        public IActionResult Index(AccountViewModel account)
        {
            if(HttpContext.Session.GetString("Username") == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View(account);
        }
        public IActionResult AddToFavorites()
        {
            return View();
        }
    }
}