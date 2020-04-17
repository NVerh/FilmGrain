using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FilmGrain.Controllers
{
    public class FilmController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string searchText)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("TmdbApi","Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult GetFilm(int id)
        {
            return View();
        }
    }
}