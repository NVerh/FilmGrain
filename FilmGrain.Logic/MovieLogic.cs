using FilmGrain.DTO;
using FilmGrain.Interfaces.DAL;
using FilmGrain.Interfaces.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace FilmGrain.Logic
{
    public class MovieLogic : IMovieLogic
    {
        private readonly IMovieDAL _context;
        public MovieLogic(IMovieDAL context)
        {
            _context = context;
        }
        public IEnumerable<MovieDTO> GetMovies(string searchString)
        {
            return _context.GetMovies(searchString);
        }
        public MovieDTO FilterMoviesByString(string searchString, IEnumerable<MovieDTO> movies)
        { 
            MovieDTO filteredMovie = new MovieDTO();
            foreach(MovieDTO movie in movies)
            {
                if(String.Equals(searchString, movie.Title))
                {
                    filteredMovie = movie;
                    return filteredMovie;
                }
            }
            return filteredMovie;
        }
        private double CalculateAverageRating(List<RatingDTO> ratings)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<MovieDTO> GetRandomMovies()
        {
            return _context.GetRandomMovies();
        }
        public IEnumerable<MoviePosterDTO> GetRandomPosters()
        {
            return _context.GetRandomPosters();
        }

        public void Create(MovieDTO obj)
        {
            _context.Create(obj);
        }

        public MovieDTO Read(int key)
        {
            return _context.Read(key);
        }

        public void Update(MovieDTO obj)
        {
            _context.Update(obj);
        }

        public void Delete(MovieDTO obj)
        {
            _context.Delete(obj);
        }
    }
}
