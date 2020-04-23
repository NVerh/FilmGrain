using DM.MovieApi;
using DM.MovieApi.MovieDb.Movies;
using System;

namespace FilmGrain.API
{
    public class MovieDbSettings : IMovieDbSettings
    {
        public string ApiKey => "7fbd33a0ba717ecb076c4c4f2e21f824";

        public string ApiUrl => "https://api.themoviedb.org/3/";
    }
}
