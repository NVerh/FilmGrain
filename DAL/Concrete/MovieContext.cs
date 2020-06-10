using DAL.Access;
using FilmGrain.DTO;
using FilmGrain.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace FilmGrain.DAL.Concrete
{
    public class MovieContext : IMovieContext
    {
        public string Create(MovieDTO obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(MovieDTO obj)
        {
            throw new NotImplementedException();
        }

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

        public IEnumerable<MovieDTO> GetRandomMovies()
        {
            List<MovieDTO> movies = new List<MovieDTO>();
            GenreDTO genre = new GenreDTO();
            using (SqlConnection conn = new SqlConnection(DBAccess._connectionstring))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.spMovie_GetRandomMovies", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    using (SqlDataReader datareader = cmd.ExecuteReader())
                    {
                        while (datareader.Read())
                        {
                            int Id = datareader.GetInt32(0);
                            string Title = datareader.GetString(1);
                            DateTime dateTime = datareader.GetDateTime(2);
                            string director = datareader.GetString(3);
                            decimal averageRating = datareader.GetDecimal(4);
                            genre.Description = datareader.GetString(5);
                            if (!datareader.IsDBNull(0) && !movies.Any(i => i.Id == Id))
                            {
                                MovieDTO movie = new MovieDTO
                                {
                                    Id = Id,
                                    Title = Title,
                                    DateReleased = dateTime,
                                    Director = director,
                                    AverageRating = averageRating,
                                    Genre = new List<GenreDTO>
                                    {
                                        genre
                                    }
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
        public IEnumerable<MoviePosterDTO> GetRandomPosters()
        {
            List<MoviePosterDTO> moviePosters = new List<MoviePosterDTO>();
            using (SqlConnection conn = new SqlConnection(DBAccess._connectionstring))
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
            return moviePosters;
        }

        public MovieDTO Read(string key)
        {
            throw new NotImplementedException();
        }

        public void Update(MovieDTO obj)
        {
            throw new NotImplementedException();
        }
    }
}
