﻿using FilmGrain.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using FilmGrain.DTO;

namespace FilmGrain.Interfaces.Logic
{
    public interface IMovieLogic
    {
        public IEnumerable<MovieDTO> GetMovies(string searchString);
        public MovieDTO FilterMoviesByString(string searchString, IEnumerable<MovieDTO> movies);
    }
}