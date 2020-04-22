using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmGrain.Models.User;
using FilmGrain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Services;
using AutoMapper;
using DTO;
using FilmGrain.Interfaces.Logic;

namespace FilmGrain.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILoginRepository _loginRepo;
        private readonly IUserLogic _userLogic;
        private readonly IMapper _mapper;
        

        public AccountController(ILoginRepository loginRepo, IUserLogic userLogic, IMapper mapper )
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