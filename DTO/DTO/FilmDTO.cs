using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace DTO
{
    public class FilmDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public GenreDTO MyProperty { get; set; }
        public string Director { get; set; }
        public DateTime DateReleased { get; set; }
        public decimal AverageRating { get; set; }
    }
}
