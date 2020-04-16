using FilmGrain.Models.Film;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmGrain.Models
{
    public class CreditsViewModel
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("cast")]
        public List<CastViewModel> Cast { get; set; }
        [JsonProperty("crew")]
        public List<CrewViewModel> Crew { get; set; }
    }
}
