using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmGrain.Models
{
    public class FilmViewModel
    {
        [Required]
        public int Id { get; set; }
        public string SearchText { get; set; }
        public string Title { get; set; }
        public int? Runtime { get; set; }
        public List<GenreViewModel> Genres { get; set; }
        [JsonProperty()]
        public long Budget { get; set; }
        [JsonProperty("imdb_id")]
        public string ImdbId { get; set; }
        [JsonProperty("overview")]
        public string OverView { get; set; }
        [JsonProperty("credits")]
        public CreditsViewModel Credits { get; set; }
    }
}
