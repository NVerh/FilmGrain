using FilmGrain.DTO;
using FilmGrain.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class MockReadRepository : IMovieContext, IReadRepository
    {
        List<MovieDTO> _movies = new List<MovieDTO>
        {
            new MovieDTO{ Id = 1, Title = "Avatar", Director = "James Cameron", DateReleased = new DateTime(2009, 12, 17), AverageRating = 4.2m},
            new MovieDTO{ Id = 2, Title = "Gone With The Wind", Director= "Victor Fleming", DateReleased = new DateTime(1949, 3, 3), AverageRating = 4.7m},
            new MovieDTO{ Id = 3, Title = "The Invisible Man", Director = "James Whale", DateReleased = new DateTime(1933, 3, 30), AverageRating = 4.1m},
            new MovieDTO{ Id = 4, Title = "Bright", Director = "David Ayer", DateReleased = new DateTime(2017,12,13), AverageRating = 3.2m},
            new MovieDTO{ Id = 5, Title = "Tremors", Director ="Ron Underwood", DateReleased = new DateTime(1990,9,8), AverageRating = 3.9m},
        };

        public string Create(MovieDTO obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(MovieDTO obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MovieDTO> GetMovies(int Id)
        {
            var movies = _movies.Where(m => m.Title.Equals(Id));
            return movies;
        }

        public IEnumerable<MovieDTO> GetMovies(string searchString)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MovieDTO> GetRandomMovies()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MoviePosterDTO> GetRandomPosters()
        {
            throw new NotImplementedException();
        }

        public MovieDTO Read(string key)
        {
            throw new NotImplementedException();
        }

        public void Update(MovieDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
