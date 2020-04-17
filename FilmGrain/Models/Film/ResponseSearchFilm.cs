using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmGrain.Models.Film
{
    public class ResponseSearchFilm
    {
        public int Page { get; set; }
        public List<ResultViewModel> Results { get; set; }
        public int TotalResults { get; set; }
        public int TotalPages { get; set; }
    }
}
