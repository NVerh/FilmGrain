using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmGrain.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FilmGrain.Controllers
{
    public class ResultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}