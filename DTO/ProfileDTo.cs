using System;
using System.Collections.Generic;
using System.Text;

namespace FilmGrain.Interfaces
{
    public class ProfileDTO
    {
        public int Id { get; set; }
        public UserDTO UserId { get; set; }
        public List<MovieDTO> WatchedFilms { get; set; }
        public List<MovieDTO> FavoriteFilms { get; set; }
        public ICollection<ReviewDTO> Reviews { get; set; }
    }
}
