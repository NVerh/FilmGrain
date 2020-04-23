using DAL.Access;
using FilmGrain.Interfaces;
using FilmGrain.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace FilmGrain.DAL.Concrete
{
    public class MovieContext : IMovieContext
    {
        public IEnumerable<MovieDTO> GetMovies(string searchString)
        {
            List<MovieDTO> movies = new List<MovieDTO>();
            using(SqlConnection conn = new SqlConnection(DBAccess._connectionstring))
            {
                using(SqlCommand cmd = new SqlCommand("dbo.spMovie_GetMovies", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Title", searchString);
                    conn.Open();
                    using(SqlDataReader datareader = cmd.ExecuteReader())
                    {
                        while (datareader.Read())
                        {
                            int Id = datareader.GetInt32(0);
                            string Title = datareader.GetString(1);
                            DateTime dateTime = datareader.GetDateTime(2);
                            string director = datareader.GetString(3);
                            decimal averageRating = datareader.GetDecimal(4);
                            if(!datareader.IsDBNull(0) && searchString == Title)
                            {
                                MovieDTO movie = new MovieDTO
                                {
                                    Id = Id,
                                    Title = Title,
                                    DateReleased = dateTime,
                                    Director = director,
                                    AverageRating = averageRating
                                };
                                movies.Add(movie);
                            }
                        }
                    }
                    conn.Dispose();
                }
            }
            return movies;
        }
    }
}
