using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Authorization;
using FilmGrain.Models;
using System.Diagnostics;

namespace FilmGrain.Controllers
{
    [AllowAnonymous]
    public class ErrorController : Controller
    {
        public IActionResult Error(ArgumentException ex)
        {
            return View(ex);
        }
        public IActionResult Index()
        {
            ViewBag.MyString = TempData["ErrorMessage"];
            return View();
        }
    }
}