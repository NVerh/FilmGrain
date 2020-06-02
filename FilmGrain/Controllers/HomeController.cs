using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FilmGrain.Models;
using FilmGrain.Interfaces.Logic;

namespace FilmGrain.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieLogic _movie;

        public HomeController(ILogger<HomeController> logger, IMovieLogic movie)
        {
            _logger = logger;
            _movie = movie;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult GetMovies(string searchText)
        {
            if(!ModelState.IsValid)
            {
                var Films =_movie.GetMovies(searchText);
            }
            return View();
        }
    }
}
