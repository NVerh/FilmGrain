using DAL.Access;
using FilmGrain.DTO;
using FilmGrain.Interfaces.DAL;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Xml;

namespace FilmGrain.DAL.Concrete
{
    public class MovieContext : IMovieDAL
    {
        public void Create(MovieDTO obj)
        {
            using (SqlConnection conn = new SqlConnection(DBAccess._connectionstring))
            {
                try
                {


                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.spMovie_Create", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Title", obj.Title);
                        cmd.Parameters.AddWithValue("@ReleaseDate", obj.DateReleased);
                        cmd.Parameters.AddWithValue("@Director", obj.Director);
                        cmd.Parameters.AddWithValue("@Rating", obj.AverageRating);
                        cmd.Parameters.AddWithValue("@Genre", obj.Genre);
                        cmd.ExecuteNonQuery();
                    }
                    conn.Dispose();
                }
                catch (SqlException exv)
                {
                    Console.WriteLine(exv);
                    throw new ArgumentException("Database error; cannot create Movie.");
                }
            }
        }

        public void Delete(MovieDTO obj)
        {
            using (SqlConnection conn = new SqlConnection(DBAccess._connectionstring))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.spMovie_Delete", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@key", obj.Id);
                        cmd.ExecuteNonQuery();
                    }
                    conn.Dispose();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
                    throw new ArgumentException("Database error; cannot delete Movie.");
                }
            }
        }

        public IEnumerable<MovieDTO> GetMovies(string searchString)
        {
            List<MovieDTO> movies = new List<MovieDTO>();
            using (SqlConnection conn = new SqlConnection(DBAccess._connectionstring))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.spMovie_GetMovies", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Title", searchString);
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
                                if (!datareader.IsDBNull(0) && searchString == Title)
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
                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
                    throw new ArgumentException("Database error; cannot get Movies");
                }
                return movies;
            }
        }

        public IEnumerable<MovieDTO> GetRandomMovies()
        {
            List<MovieDTO> movies = new List<MovieDTO>();
            GenreDTO genre = new GenreDTO();
            using (SqlConnection conn = new SqlConnection(DBAccess._connectionstring))
            {
                try
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
                                        Genre = genre
                                    };
                                    movies.Add(movie);
                                }
                            }
                        }
                        conn.Dispose();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
                    throw new ArgumentException("Database error; cannot get random movies");
                }
                return movies;
            }
        }
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

        public MovieDTO Read(int key)
        {
            MovieDTO movie = new MovieDTO();
            GenreDTO genre = new GenreDTO();
            using (SqlConnection conn = new SqlConnection(DBAccess._connectionstring))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.spMovie_Read", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", key);
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
                                string movieUrl = datareader.GetString(6);
                                if (!datareader.IsDBNull(0))
                                {
                                    movie.Id = Id;
                                    movie.Title = Title;
                                    movie.DateReleased = dateTime;
                                    movie.Director = director;
                                    movie.AverageRating = averageRating;
                                    movie.Genre = genre;
                                    movie.PosterURL = movieUrl;
                                }
                            }
                        }
                        conn.Dispose();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
                    throw new ArgumentException("Database error; cannot read Movies");
                }
                return movie;
            }
        }

            public void Update(MovieDTO obj)
            {
                using (SqlConnection conn = new SqlConnection(DBAccess._connectionstring))
                {
                    try
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand("dbo.spMovie_Update", conn))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Rating", obj.AverageRating);
                            cmd.ExecuteNonQuery();
                            conn.Dispose();
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine(ex);
                        throw new ArgumentException("Database error; cannot update Movies");
                    }
                }
            }
        }
    }
