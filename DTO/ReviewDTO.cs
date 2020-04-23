using System;
using System.Collections.Generic;
using System.Text;

namespace FilmGrain.Interfaces
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public FilmDTO ReviewedFilm { get; set; }
        public RatingDTO FilmRating { get; set; }
    }
}
