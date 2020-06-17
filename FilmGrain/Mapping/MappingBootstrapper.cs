using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace FilmGrain.Mapping
{
    public static class MappingBootstrapper
    {
        public static void Initiliaze()
        {
            new MappingProfile();
        }
    }
}
