using System;
using System.Collections.Generic;
using System.Text;

namespace FilmGrain.DTO
{
    public class ProfileDTO
    {
        public int Id { get; set; }
        public UserDTO User { get; set; }
        public IEnumerable<MovieDTO> WatchedMovies { get; set; }
        public IEnumerable<MovieDTO> FavoriteMovies { get; set; }
        public IEnumerable<ReviewDTO> Reviews { get; set; }
        public IEnumerable<RatingDTO> Ratings { get; set; }
    }
}
