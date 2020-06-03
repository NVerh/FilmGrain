using FilmGrain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmGrain.Interfaces.DAL
{
    public interface IMovieContext
    {
        public IEnumerable<MovieDTO> GetMovies(string searchString);
    }
}
