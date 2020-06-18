using System;
using System.Collections.Generic;
using System.Text;
using FilmGrain.DAL.Mock;
using FilmGrain.Interfaces.Mock;

namespace FilmGrain.Test
{
    public class MovieTests
    {
        private readonly IMovieMock _movieMock = new MovieMockRepository();
    }
}
