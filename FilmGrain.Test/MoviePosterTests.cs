using FilmGrain.DAL.Mock;
using FilmGrain.DTO;
using FilmGrain.Interfaces.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace FilmGrain.Test
{
    public class MoviePosterTests
    {
        private readonly IPosterMock _poster = new PosterMockRepository();

        [Fact]
        public void GetPosters_Compare_With_Normal_Collection()
        {
            List<MoviePosterDTO> posters = new List<MoviePosterDTO>()
            {
                new MoviePosterDTO{ Id = 1},
                new MoviePosterDTO{ Id = 2},
                new MoviePosterDTO{ Id = 3},
            };
            List<MoviePosterDTO> dbposters = _poster.GetRandomPosters().ToList();

            var firstPoster = posters.First();
            var firstDbPoster = dbposters.First();

            Assert.NotEqual(firstDbPoster, firstPoster);
        }
    }
}
