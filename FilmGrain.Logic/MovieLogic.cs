using DM.MovieApi.ApiResponse;
using DM.MovieApi.MovieDb.Movies;
using FilmGrain.Interfaces.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FilmGrain.Logic
{
    public class MovieLogic : IMovieLogic
    {
        private readonly IMovieCall _movieCall;
        public MovieLogic(IMovieCall movieCall)
        {
            _movieCall = movieCall;
        }
        public Task<ApiSearchResponse<MovieInfo>> GetMovieInfo(string keyword)
        {
            return _movieCall.GetMovieInfo(keyword);
        }
    }
}
