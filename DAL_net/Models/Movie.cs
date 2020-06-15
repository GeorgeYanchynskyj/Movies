using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DAL.Models
{
    public class Movie
    {
        public int Id { get; set; }
        
        public string Overview { get; set; }
        public string Title { get; set; }
        public double Popularity { get; set; }

        [JsonProperty(PropertyName = "vote_average")]
        public double VoteAverage { get; set; }

        [JsonProperty(PropertyName = "original_language")]
        public string OriginalLanguage { get; set; }

        [JsonProperty(PropertyName = "release_date")]
        public DateTime ReleaseDate { get; set; }

        public Movie(int id, string title, string overview, double popularity, double voteAvarage, string originalLanguage, DateTime releaseDate)
        {
            Id = id;
            Overview = overview;
            Title = title;
            Popularity = popularity;
            VoteAverage = voteAvarage;
            OriginalLanguage = originalLanguage;
            ReleaseDate = releaseDate;
        }
        public Movie() { }
    }
}
