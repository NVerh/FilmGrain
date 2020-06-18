using DAL.Access;
using FilmGrain.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace FilmGrain.DAL.Concrete
{
    public class PosterContext : FilmGrain.Interfaces.DAL.IPosterDAL
    {
        public IEnumerable<MoviePosterDTO> GetRandomPosters()
        {
            List<MoviePosterDTO> moviePosters = new List<MoviePosterDTO>();
            using (SqlConnection conn = new SqlConnection(DBAccess._connectionstring))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.spMovie_GetRandomMoviePosters", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        conn.Open();
                        using (SqlDataReader datareader = cmd.ExecuteReader())
                        {
                            while (datareader.Read())
                            {
                                int id = datareader.GetInt32(0);
                                string title = datareader.GetString(1);
                                string posterUrl = datareader.GetString(2);
                                if (!datareader.IsDBNull(0))
                                {
                                    MoviePosterDTO poster = new MoviePosterDTO
                                    {
                                        Id = id,
                                        Title = title,
                                        PosterURL = posterUrl,

                                    };
                                    moviePosters.Add(poster);
                                }
                            }
                        }
                        conn.Dispose();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
                    throw new ArgumentException("Database error; cannot get random Posters");
                }
            }
            return moviePosters;
        }
    }
}
