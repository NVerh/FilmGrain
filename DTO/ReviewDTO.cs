using System;
using System.Collections.Generic;
using System.Text;
using FilmGrain.Interfaces;

namespace FilmGrain.Interfaces
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public MovieDTO ReviewedMovie{ get; set; }
        public RatingDTO FilmRating { get; set; }
    }
}
