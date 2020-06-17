using FilmGrain.Models.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmGrain.Models.User
{
    public class ProfileViewModel
    {
        public List<MovieViewModel> FavoriteMovies { get; set; }
    }
}
