using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmGrain.Models.User;
using FilmGrain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Services;
using AutoMapper;
using FilmGrain.Interfaces;
using FilmGrain.Interfaces.Logic;
using FilmGrain.DTO;

namespace FilmGrain.Controllers
{
    public class AccountController : Controller
    {
        private readonly LoginRepository _loginRepo;
        private readonly IUserLogic _userLogic;
        private readonly IMapper _mapper;
        

        public AccountController(LoginRepository loginRepo, IUserLogic userLogic, IMapper mapper )
        {
            _loginRepo = loginRepo;
            _userLogic = userLogic;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(!ModelState.IsValid)
            {
                _userLogic.CreateAccount(_mapper.Map<UserDTO>(model));
                ViewData["Message"] = "Account Created!";
                return View(model);
            }
            return View();
        }
        [HttpGet]
        public IActionResult Login(string returnUrl = "")
        {
            var model = new LoginViewModel { ReturnUrl = returnUrl };
            return View(model);
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if(!ModelState.IsValid)
            {
                if(!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                {
                    var user = _userLogic.GetAccountByEmail(model.Email);
                    if(user == null)
                    {
                        return View();
                    }
                    return View(user);
                }
            }
            return View();

        }
    }
}