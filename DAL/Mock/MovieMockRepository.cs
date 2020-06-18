using FilmGrain.DTO;
using FilmGrain.Interfaces.DAL;
using FilmGrain.Interfaces.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace FilmGrain.DAL.Mock
{
    public class MovieMockRepository : IMovieMock
    {
        public List<MovieDTO> _movies = new List<MovieDTO>
        {
            new MovieDTO{ Id = 1, Title = "Avatar", Director = "James Cameron", DateReleased = new DateTime(2009, 12, 17), AverageRating = 4.2m},
            new MovieDTO{ Id = 2, Title = "Gone With The Wind", Director= "Victor Fleming", DateReleased = new DateTime(1949, 3, 3), AverageRating = 4.7m},
            new MovieDTO{ Id = 3, Title = "The Invisible Man", Director = "James Whale", DateReleased = new DateTime(1933, 3, 30), AverageRating = 4.1m},
            new MovieDTO{ Id = 4, Title = "Bright", Director = "David Ayer", DateReleased = new DateTime(2017,12,13), AverageRating = 3.2m},
            new MovieDTO{ Id = 5, Title = "Tremors", Director ="Ron Underwood", DateReleased = new DateTime(1990,9,8), AverageRating = 3.9m},
        };

        public bool Create(MovieDTO obj)
        {
            _movies.Add(obj);
            if(_movies.Contains(obj))
            {
                return true;
            }
            return false;
        }

        public bool Delete(MovieDTO obj)
        {
            _movies.RemoveAt(obj.Id);
            if (!_movies.Contains(obj) && obj.Id != 0)
            {
                return true;
            }
            return false;
        }

        public IEnumerable<MovieDTO> GetMovies(string searchString)
        {
            var movies = _movies.Where(m => m.Title.Contains(searchString));
            return movies;
        }

        public IEnumerable<MovieDTO> GetRandomMovies()
        {
            Random r = new Random();
            int toSkip = r.Next(0);
            var movies = _movies.Skip(toSkip).Take(3);
            return movies;
        }

        public MovieDTO Read(int key)
        {
            var movie = _movies.Single(x => x.Id == key);
            return movie;
        }

        public bool Update(MovieDTO obj)
        {
            obj = (from p in _movies
                   where p.Id == obj.Id
                   select p).SingleOrDefault();
            if (obj != null)
            {
                return true;
            }
            return false;
        }
    }
}
