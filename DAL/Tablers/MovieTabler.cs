using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DAL.Models;

namespace DAL.Tablers
{
    public class MovieTabler
    {
        private readonly IDbConnection _dbConnection;

        public MovieTabler()
        {
            _dbConnection = DBAccess.GetDbConnection();
        }

        //public List<Movie> GetBooks()
        //{
            
        //    var query = "SELECT * FROM [Movie]";
        //    var movies = new List<Movie>();

        //    using (var reader = _dbConnection.ExecuteReader(query))
        //    {
        //        while (reader.Read())
        //        {
        //            movies.Add(new Movie()
        //            {
        //                Id = Convert.ToInt32(reader["Id"]),
        //                Overview = reader["Overview"].ToString(),
        //                Title = reader["Title"].ToString(),
        //                Popularity = Convert.ToDouble(reader["Popularity"]),
        //                VoteAverage = Convert.ToDouble(reader["VoteAverage"]),
        //                OriginalLanguage = reader["OriginalLanguage"].ToString(),
        //                ReleaseDate = Convert.ToDateTime(reader["ReleaseDate"]),
        //            });
        //        }
        //    }

        //    return movies;
        //}

        //public Movie GetBookById(int id)
        //{
            
        //    var query = "SELECT * FROM [Movie] WHERE [Id] = @IdParameter";
        //    var movie = new Movie();

        //    using (var reader = _dbConnection.ExecuteReader(query, new { IdParameter = id }))
        //    {
        //        while (reader.Read())
        //        {
        //            movie = new Movie()
        //            {
        //                Id = Convert.ToInt32(reader["Id"]),
        //                Overview = reader["Overview"].ToString(),
        //                Title = reader["Title"].ToString(),
        //                Popularity = Convert.ToDouble(reader["Popularity"]),
        //                VoteAverage = Convert.ToDouble(reader["VoteAverage"]),
        //                OriginalLanguage = reader["OriginalLanguage"].ToString(),
        //                ReleaseDate = Convert.ToDateTime(reader["ReleaseDate"]),
        //            };
        //        }
        //    }

        //    return movie;
        //}

        //public bool InsertBook(Movie movie)
        //{

        //    var rowsAffected = _dbConnection.Execute(@"INSERT INTO [Books]([Id],[Overview],[Title],[Popularity],[VoteAvarage],[OriginalLanguage],[ReleaseDate])
        //                                                         VALUES(@BookName,@BookYear,@BookLanguage,@BookAvailable,@BookAuthorID)", new
        //    {
        //        Id = movie.Id,
        //        Overview = movie.Overview,
        //        Title = movie.Title,
        //        Popularity = movie.Popularity,
        //        VoteAverage = movie.VoteAvarage,
        //        OriginalLanguage = movie.OriginalLanguage,
        //        ReleaseDate = movie.ReleaseDate
        //    });

        //    return rowsAffected > 0;
        //}
    }
}
