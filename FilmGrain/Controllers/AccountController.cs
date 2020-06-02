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
    }
}