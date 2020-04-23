using System;
using System.Collections.Generic;
using System.Text;
using DM.MovieApi.ApiResponse;
using DM.MovieApi.MovieDb.Movies;
using System.Threading.Tasks;

namespace FilmGrain.Interfaces.Interface
{
    public interface IMovieLogic
    {
        public Task<ApiSearchResponse<MovieInfo>> GetMovieInfo(string keyword);       
    }
}
