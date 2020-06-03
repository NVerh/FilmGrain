using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FilmGrain.Models;
using FilmGrain.Models.User;
using FilmGrain.DTO;

namespace FilmGrain.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDTO, RegisterViewModel>().ReverseMap();
        }
    }
}
