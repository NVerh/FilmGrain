using FilmGrain.Models.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmGrain.Models
{
    public class SearchResultViewModel
    {
        public int Page { get; set; }
        public List<MovieViewModel> results { get; set; }
        public int Total_Results { get; set; }
        public int Total_Pages { get; set; }
    }
}
