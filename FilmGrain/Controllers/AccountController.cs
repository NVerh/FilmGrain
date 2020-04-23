using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmGrain.Models.User;
using FilmGrain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Services;
using FilmGrain.Logic;
using AutoMapper;
using FilmGrain.Interfaces;

namespace FilmGrain.Controllers
{
    public class AccountController : Controller
    {
        private readonly LoginRepository _loginRepo;
        private readonly UserLogic _userLogic;
        private readonly IMapper _mapper;
        

        public AccountController(LoginRepository loginRepo, UserLogic userLogic, IMapper mapper )
        {
            _loginRepo = loginRepo;
            _userLogic = userLogic;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel account)
        {

            return View();
        }
        public IActionResult Register(RegisterViewModel account)
        {
            if(ModelState.IsValid)
            {

                var salt = PasswordSalt.Create();
                account.Password = PasswordHash.Create(account.Password, salt);
                _userLogic.CreateAccount(_mapper.Map<UserDTO>(account));
            }
            return View();
        }
    }
}