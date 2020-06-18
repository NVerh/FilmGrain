using FilmGrain.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using FilmGrain.DTO;

namespace FilmGrain.Interfaces.Logic
{
    public interface IMovieLogic : IMovieDAL
    {
        public IEnumerable<MovieDTO> GetMovies(string searchString);
        public IEnumerable<MovieDTO> GetRandomMovies();
        public MovieDTO FilterMoviesByString(string searchString, IEnumerable<MovieDTO> movies);
    }
}
