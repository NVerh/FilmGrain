using System;
using System.Collections.Generic;
using System.Text;

namespace FilmGrain.Interfaces
{
    public class ProfileDTO
    {
        public int Id { get; set; }
        public UserDTO UserId { get; set; }
        public List<MovieDTO> WatchedMovies { get; set; }
        public List<MovieDTO> FavoriteMovies { get; set; }
        public ICollection<ReviewDTO> Reviews { get; set; }
    }
}
