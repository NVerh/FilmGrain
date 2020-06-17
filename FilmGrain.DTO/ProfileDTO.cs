using System;
using System.Collections.Generic;
using System.Text;

namespace FilmGrain.DTO
{
    public class ProfileDTO
    {
        public int Id { get; set; }
        public UserDTO User { get; set; }
        public List<MovieDTO> WatchedMovies { get; set; }
        public List<MovieDTO> FavoriteMovies { get; set; }
        public List<ReviewDTO> Reviews { get; set; }
        public List<RatingDTO> Ratings { get; set; }
    }
}
