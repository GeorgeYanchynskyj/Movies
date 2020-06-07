using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Movie
    {
        public int Id { get; set; }
        
        public string Overview { get; set; }
        public string Title { get; set; }
        public double Popularity { get; set; }

        public double VoteAverage { get; set; }

        public string OriginalLanguage { get; set; }

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
