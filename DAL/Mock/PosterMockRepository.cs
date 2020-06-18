using FilmGrain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FilmGrain.DAL.Mock
{
    public class PosterMockRepository
    {
        List<MoviePosterDTO> _posters = new List<MoviePosterDTO>
        {
            new MoviePosterDTO{ Id = 1, Title ="Gone With The Wind", PosterURL ="https://theposterdb.com/api/assets/43275"},
            new MoviePosterDTO{ Id = 2, Title ="The Invisible Man", PosterURL ="https://theposterdb.com/api/assets/17829"},
            new MoviePosterDTO{ Id = 3, Title ="Bright", PosterURL="https://theposterdb.com/api/assets/75203"}
        };
        public IEnumerable<MoviePosterDTO> GetRandomPosters()
        {
            Random r = new Random();
            int toSkip = r.Next(0, _posters.Count);
            var posters = _posters.Skip(toSkip).Take(3);
            return posters;
        }
    }
}
