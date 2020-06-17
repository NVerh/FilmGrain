using System;
using System.Collections.Generic;
using System.Text;

namespace FilmGrain.DTO
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public MovieDTO ReviewedMovie{ get; set; }
        public RatingDTO MovieRating { get; set; }
    }
}
