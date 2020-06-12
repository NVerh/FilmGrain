using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FilmGrain.Interfaces.Logic;
using FilmGrain.Models.Movie;
using Microsoft.AspNetCore.Mvc;

namespace FilmGrain.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieLogic _movieLogic;
        private readonly IMapper _mapper;

        public MovieController(IMovieLogic movieLogic, IMapper mapper)
        {
            _movieLogic = movieLogic;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetMovie(string searchstring)
        {
            MovieViewModel movieVM = new MovieViewModel();
            if(ModelState.IsValid)
            {
                movieVM = _mapper.Map<MovieViewModel>(_movieLogic.FilterMoviesByString(searchstring, _movieLogic.GetMovies(searchstring)));
                return View(movieVM);
            }
            return View();
        }
        [HttpGet]
        public IActionResult Overview(MovieViewModel movie)
        {
            return View(movie);
        }
    }
}