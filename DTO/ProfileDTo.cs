﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ProfileDTo
    {
        public int Id { get; set; }
        public UserDTO UserId { get; set; }
        public ICollection<FilmDTO> WatchedFilms { get; set; }
        public ICollection<FilmDTO> FavoriteFilms { get; set; }
        public ICollection<ReviewDTO> Reviews { get; set; }
    }
}
