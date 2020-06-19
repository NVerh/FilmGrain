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
using FilmGrain.Models.User;
using FilmGrain.Repositories;
using Microsoft.AspNetCore.Http;

namespace FilmGrain.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieLogic _movie;
        private readonly IMapper _mapper;
        private readonly IPosterLogic _poster;

        public HomeController(IMovieLogic movie, IMapper mapper, IPosterLogic poster)
        {
            _movie = movie;
            _mapper = mapper;
            _poster = poster;
        }

        public IActionResult Index(IndexViewModel index, AccountViewModel account)
        {
            try
            {
                index.RandomMoviePosters = _mapper.Map<IEnumerable<MoviePosterDTO>, List<MoviePosterViewModel>>(_poster.GetRandomPosters());
                return View(index);
            }
            catch(ArgumentException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index", "Error");
            }
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
                try
                {

                    var Films = _movie.GetMovies(searchText);
                }
                catch(ArgumentException ex)
                {
                    TempData["ErrorMessage"] = ex.Message;
                    return RedirectToAction("Index", "Error");
                }
            }
            return View();
        }
        public IActionResult GoToOverview(int id)
        {
            try
            {
                MovieViewModel movie = new MovieViewModel();
                movie = _mapper.Map<MovieViewModel>(_movie.Read(id));
                return RedirectToAction("Overview", "Movie", movie);
            }
            catch(ArgumentException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index", "Error");
            }
        }
    }
}
