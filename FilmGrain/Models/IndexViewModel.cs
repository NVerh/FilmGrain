using FilmGrain.Models.Movie;
using FilmGrain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmGrain.Models
{
    public class IndexViewModel
    {
        public List<MoviePosterViewModel> RandomMoviePosters { get; set; }
        public AccountViewModel Account { get; set; }
    }
}
