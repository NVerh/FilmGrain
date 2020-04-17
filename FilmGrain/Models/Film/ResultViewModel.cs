using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmGrain.Models.Film
{
    public class ResultViewModel
    {
        public int Id { get; set; }
        public string PosterPath { get; set; }
        public string Title {get; set;}
        public string ReleaseDate { get; set; }
    }
}
