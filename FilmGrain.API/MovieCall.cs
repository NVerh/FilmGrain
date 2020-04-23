using DM.MovieApi;
using DM.MovieApi.ApiResponse;
using DM.MovieApi.MovieDb.Movies;
using FilmGrain.Interfaces.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FilmGrain.API
{
    public class MovieCall : IMovieCall
    {
        public async Task<ApiSearchResponse<MovieInfo>> GetMovieInfo(string keyword)
        {
            var movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;
            ApiSearchResponse<MovieInfo> response = await movieApi.SearchByTitleAsync(keyword);
            return response;
        }
    }
}
