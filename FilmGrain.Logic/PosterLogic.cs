using FilmGrain.DTO;
using FilmGrain.Interfaces.DAL;
using FilmGrain.Interfaces.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmGrain.Logic
{
    public class PosterLogic : IPosterLogic
    {
        private readonly IPosterDAL _context;
        public PosterLogic(IPosterDAL context)
        {
            _context = context;
        }
        public IEnumerable<MoviePosterDTO> GetRandomPosters()
        {
            return _context.GetRandomPosters();
        }
    }
}
