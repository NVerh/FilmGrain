﻿using System;
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
using System.Linq.Expressions;

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
        public IActionResult Register(RegisterViewModel model)
        {
            try
            {
                _userLogic.CreateAccount(_mapper.Map<UserDTO>(model));
                ViewData["Message"] = "Account Created!";
                return RedirectToAction("Login");
            }
            catch(ArgumentException exc)
            {
                ModelState.AddModelError("Error", exc.Message);
                return View();
            }
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            try
            {
                var user = _userLogic.GetAccountByEmail(model.Email);
                if (user != null)
                {
                    _loginRepo.SetLoginSession(user.UserName, user.Id);
                    return RedirectToAction("Index", "Home");
                }
            }
            catch(ArgumentException exc)
            {
                ModelState.AddModelError("Error", exc.Message);
            }
            return View();
        }
        public IActionResult Logout()
        {
            try
            {
                _loginRepo.RemoveLoginSession();
                return RedirectToAction("Login");
            }
            catch(ArgumentException exc)
            {
                ModelState.AddModelError("Error", exc.Message);
                return View();
            }
        }
    }
}