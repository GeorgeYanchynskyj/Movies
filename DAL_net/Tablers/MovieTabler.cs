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

        public List<Movie> GetMovies()
        {
            IDbCommand command = _dbConnection.CreateCommand();
            command.CommandText = "SELECT * from dbo.Movie";
            //var res = command.ExecuteReader();
            var movies = new List<Movie>();

            _dbConnection.Open();

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    movies.Add(new Movie()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Overview = reader["Overview"].ToString(),
                        Title = reader["Title"].ToString(),
                        Popularity = Convert.ToDouble(reader["Popularity"]),
                        VoteAverage = Convert.ToDouble(reader["VoteAverage"]),
                        OriginalLanguage = reader["OriginalLanguage"].ToString(),
                        ReleaseDate = Convert.ToDateTime(reader["ReleaseDate"]),
                    });
                }
            }

            _dbConnection.Close();

            return movies;
        }

        public bool UpsertMovie(Movie movie)
        {
            IDbCommand command = _dbConnection.CreateCommand();
            command.CommandText = $"EXEC dbo.UpsertMovie @Id={movie.Id}, @Overview='{movie.Overview.Replace("'", "`")}', @Title='{movie.Title.Replace("'", "`")}', @Popularity={(int)movie.Popularity}, @VoteAverage={(int)movie.VoteAverage}, @OriginalLanguage='{movie.OriginalLanguage}', @ReleaseDate='2020-01-02' "; //{movie.ReleaseDate}"; 2020-01-01

            _dbConnection.Open();

            var res = command.ExecuteNonQuery();

            _dbConnection.Close();

            return res > 0;
        }

        //public bool InsertBook(Movie movie)
        //{
        //    IDbCommand command = _dbConnection.CreateCommand();
        //    command.CommandText = "SELECT * from dbo.Movie";
        //    return (string)command.ExecuteScalar();

        //    var rowsAffected = _dbConnection.Execute(@"INSERT INTO [Books]([Id],[Overview],[Title],[Popularity],[VoteAvarage],[OriginalLanguage],[ReleaseDate])
        //                                                         VALUES(@BookName,@BookYear,@BookLanguage,@BookAvailable,@BookAuthorID)", new
        //    {
        //        Id = movie.Id,
        //        Overview = movie.Overview,
        //        Title = movie.Title,
        //        Popularity = movie.Popularity,
        //        VoteAverage = movie.VoteAverage,
        //        OriginalLanguage = movie.OriginalLanguage,
        //        ReleaseDate = movie.ReleaseDate
        //    });

        //    var rowsAffected = _dbConnection.

        //    return rowsAffected > 0;
        //}
    }
}
