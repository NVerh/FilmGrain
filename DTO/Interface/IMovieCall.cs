using DM.MovieApi.ApiResponse;
using DM.MovieApi.MovieDb.Movies;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FilmGrain.Interfaces.Interface
{
    public interface IMovieCall
    {
        public Task<ApiSearchResponse<MovieInfo>> GetMovieInformation(string keyword);
    }
}
