using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace FilmGrain.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<GenreDTO> Genre { get; set; }
        public string Director { get; set; }
        public DateTime DateReleased { get; set; }
        public decimal AverageRating { get; set; }
    }
}
