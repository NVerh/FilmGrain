using FilmGrain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmGrain.Interfaces.DAL
{
    public interface IMovieContext : ICRUDContext<MovieDTO>
    {
        public IEnumerable<MovieDTO> GetMovies(string searchString);
        public IEnumerable<MovieDTO> GetRandomMovies();
        public IEnumerable<MoviePosterDTO> GetRandomPosters();
    }
}
