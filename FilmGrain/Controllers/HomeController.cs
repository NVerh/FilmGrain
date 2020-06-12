using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FilmGrain.Models;
using FilmGrain.Interfaces.Logic;
using AutoMapper;
using FilmGrain.Models.Movie;
using FilmGrain.DTO;

namespace FilmGrain.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMovieLogic _movie;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IMovieLogic movie, IMapper mapper)
        {
            _logger = logger;
            _movie = movie;
            _mapper = mapper;
        }

        public IActionResult Index(IndexViewModel index)
        {
            index.RandomMoviePosters = _mapper.Map<IEnumerable<MoviePosterDTO>, List<MoviePosterViewModel>>(_movie.GetRandomPosters());
            return View(index);
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
        public IActionResult GoToOverview(MovieViewModel movie)
        {
            return RedirectToAction("Overview", "Movie");
        }
    }
}
