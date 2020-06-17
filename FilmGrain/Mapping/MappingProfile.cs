using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FilmGrain.Models;
using FilmGrain.Models.User;
using FilmGrain.DTO;
using FilmGrain.Models.Movie;

namespace FilmGrain.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDTO, RegisterViewModel>().ReverseMap();
            CreateMap<UserDTO, AccountViewModel>().ReverseMap();
            CreateMap<MovieDTO, MovieViewModel>().ReverseMap();
            CreateMap<MoviePosterDTO, MoviePosterViewModel>().ReverseMap();
            CreateMap<GenreDTO, GenreViewModel>().ReverseMap();
            CreateMap<AccountViewModel, RegisterViewModel>().ReverseMap();
        }
    }
}
