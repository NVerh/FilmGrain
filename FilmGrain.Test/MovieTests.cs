using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FilmGrain.DAL.Mock;
using FilmGrain.DTO;
using FilmGrain.Interfaces.Mock;
using Newtonsoft.Json.Bson;
using Xunit;

namespace FilmGrain.Test
{
    public class MovieTests
    {
        private readonly IMovieMock _movieMock = new MovieMockRepository();

        [Theory]
        [InlineData("Gone With The Wind")]
        public void GetMovies_By_Title(string title)
        {
            MovieDTO movie = new MovieDTO
            {
                Title = title,
            };
            MovieDTO result = _movieMock.GetMovies(title).Single();
            Assert.Equal(movie.Title, result.Title);
        }
        [Theory]
        [InlineData(2)]
        public void GetMovies_By_Id(int id)
        {
            MovieDTO movie = new MovieDTO
            {
                Id = id,
            };
            MovieDTO result = _movieMock.Read(id);
            Assert.Equal(movie.Id, result.Id);

        }
        [Theory]
        [InlineData(5)]
        public void GetDirector_Name_By_Id(int id)
        {
            MovieDTO movie = new MovieDTO { Id = id, Director = "Ron Underwood"};
            MovieDTO result = _movieMock.Read(id);
            Assert.Equal(movie.Director, result.Director);
        }
        [Theory]
        [InlineData(4.10, 3)]
        public void CompareMovie_By_Rating_From_Database(decimal score, int id)
        {
            MovieDTO movie = new MovieDTO
            {
                AverageRating = score,
            };
            MovieDTO result = _movieMock.Read(id);
            Assert.Equal(movie.AverageRating, result.AverageRating);
        }
        [Fact]
        public void DeleteMovie_Succesful()
        {
            MovieDTO movie = new MovieDTO
            {
                Id = 4
            };
            bool result = _movieMock.Delete(movie);
            Assert.True(result);

        }
        [Fact]
        public void DeleteMovie_Unsuccesful()
        {
            MovieDTO movie = new MovieDTO { Id = 0 };
            bool result = _movieMock.Delete(movie);

            Assert.False(result);
        }
        [Theory]
        [InlineData(3)]
        public void GetRandomMovies_Compare_Collection_Size(int size)
        {
            List<MovieDTO> movies = new List<MovieDTO>
            {
                new MovieDTO{ Id = 1},
                new MovieDTO{ Id = 3},
                new MovieDTO{ Id  = 5},
            };
            int index = movies.Count;
            List<MovieDTO> dbmovies = _movieMock.GetRandomMovies().ToList();

            Assert.Equal(index, dbmovies.Count);

        }
        [Fact]
        public void GetRandomMovies_Compare_Collection_Position_By_Comparing_First_Element()
        {
            List<MovieDTO> movies = new List<MovieDTO>
            {
                new MovieDTO{ Id = 1},
                new MovieDTO{ Id = 2},
                new MovieDTO{ Id  = 3},
            };
            var firstElement = movies.First();
            List<MovieDTO> dbmovies = _movieMock.GetRandomMovies().ToList();
            var dbfirstElement = dbmovies.First();
            Assert.NotEqual(firstElement, dbfirstElement);
        }
        [Theory]
        [InlineData(1)]
        public void UpdateMovie_Succesful(int id)
        {
            MovieDTO movie = new MovieDTO { Id = 1 };
            bool result = _movieMock.Update(movie);

            Assert.True(result);
        }
        [Theory]
        [InlineData(0)]
        public void UpdateMovie_UnSuccesful(int id)
        {
            MovieDTO movie = new MovieDTO { Id = 0 };
            bool result = _movieMock.Update(movie);
            Assert.False(result);
        }
    
    }
}
