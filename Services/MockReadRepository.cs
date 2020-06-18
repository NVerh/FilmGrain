using FilmGrain.DTO;
using FilmGrain.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Services
{
    public class MockReadRepository : IMovieDAL, IReadRepository
    {
        List<MovieDTO> _movies = new List<MovieDTO>
        {
            new MovieDTO{ Id = 1, Title = "Avatar", Director = "James Cameron", DateReleased = new DateTime(2009, 12, 17), AverageRating = 4.2m},
            new MovieDTO{ Id = 2, Title = "Gone With The Wind", Director= "Victor Fleming", DateReleased = new DateTime(1949, 3, 3), AverageRating = 4.7m},
            new MovieDTO{ Id = 3, Title = "The Invisible Man", Director = "James Whale", DateReleased = new DateTime(1933, 3, 30), AverageRating = 4.1m},
            new MovieDTO{ Id = 4, Title = "Bright", Director = "David Ayer", DateReleased = new DateTime(2017,12,13), AverageRating = 3.2m},
            new MovieDTO{ Id = 5, Title = "Tremors", Director ="Ron Underwood", DateReleased = new DateTime(1990,9,8), AverageRating = 3.9m},
        };
        List<MoviePosterDTO> _posters = new List<MoviePosterDTO>
        {
            new MoviePosterDTO{ Id = 1, Title ="Gone With The Wind", PosterURL ="https://theposterdb.com/api/assets/43275"},
            new MoviePosterDTO{ Id = 2, Title ="The Invisible Man", PosterURL ="https://theposterdb.com/api/assets/17829"},
            new MoviePosterDTO{ Id = 3, Title ="Bright", PosterURL="https://theposterdb.com/api/assets/75203"}
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
            var movies = _movies.RemoveAll(x => x.Id == obj.Id);
            if(movies == 1)
            {
                return true;
            }
            return false;
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
            Random r = new Random();
            int toSkip = r.Next(0, _movies.Count);
            var movies = _movies.Skip(toSkip).Take(3);
            return movies;
        }

        public IEnumerable<MoviePosterDTO> GetRandomPosters()
        {
            Random r = new Random();
            int toSkip = r.Next(0, _movies.Count);
            var posters = _posters.Skip(toSkip).Take(3);
            return posters;
        }

        public MovieDTO Read(int key)
        {
            var movie = _movies.Single(x => x.Id == key);
            return movie;
        }

        public bool Update(MovieDTO obj)
        {
            obj = _movies.Single(p => p.Id == obj.Id);
            if(obj != null)
            {
                return true;
            }
            return false;
        }
    }
}
