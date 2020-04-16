using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FilmGrain.Models;
using FilmGrain.Models.User;

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
