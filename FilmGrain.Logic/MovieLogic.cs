using FilmGrain.Interfaces;
using FilmGrain.Interfaces.DAL;
using FilmGrain.Interfaces.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilmGrain.Logic
{
    public class MovieLogic : IMovieLogic
    {
        private readonly IMovieContext _context;
        public MovieLogic(IMovieContext context)
        {
            _context = context;
        }
        public IEnumerable<MovieDTO> GetMovies(string searchString)
        {
            return _context.GetMovies(searchString);
        }
        private double CalculateAverageRating(List<RatingDTO> ratings)
        {
            throw new NotImplementedException();
        }
    }
}
