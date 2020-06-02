using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmGrain.Models.Movie
{
    public class MovieViewModel
    {
        public string Title { get; set; }
        public List<GenreViewModel> Genres { get; set; } 
        public string Director { get; set;}
        public DateTime ReleaseDate { get; set; }
        public decimal AverageRating { get; set; }
    }
}
