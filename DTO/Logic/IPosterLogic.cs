using FilmGrain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmGrain.Interfaces.Logic
{
    public interface IPosterLogic
    {
        public IEnumerable<MoviePosterDTO> GetRandomPosters();
    }
}
