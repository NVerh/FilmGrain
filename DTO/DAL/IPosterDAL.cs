using FilmGrain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmGrain.Interfaces.DAL
{
    public interface IPosterDAL
    {
        IEnumerable<MoviePosterDTO> GetRandomPosters();
    }
}
