using FilmGrain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using System.Data.SqlClient;
using DAL.Access;
using System.Data.Common;
using System.Linq.Expressions;
using FilmGrain.Interfaces.DAL;
using FilmGrain.DTO;

namespace DAL.Concrete
{
    public class UserContext : IUserDAL
    {
        public void AddAccountToDB(UserDTO user)
        {
            using (SqlConnection conn = new SqlConnection(DBAccess._connectionstring))
            {
                try
                {

                    using (SqlCommand cmd = new SqlCommand("dbo.spUser_AddUser", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", user.Id);
                        cmd.Parameters.AddWithValue("@Username", user.UserName);
                        cmd.Parameters.AddWithValue("@Email", user.Email);
                        cmd.Parameters.AddWithValue("@IsAdministrator", user.IsAdmin);
                        cmd.Parameters.AddWithValue("@Password", user.Password);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Dispose();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
                    throw new ArgumentException("Database error; cannot create Account");
                }
            }
        }

        public UserDTO GetAccountFromDB(string username, string password)
        {
            UserDTO user = new UserDTO();
            using (SqlConnection conn = new SqlConnection(DBAccess._connectionstring))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.spUser_GetUser", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        conn.Open();
                        using (SqlDataReader dataReader = cmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                user.Id = dataReader.GetInt32(0);
                                user.UserName = dataReader.GetString(1);
                                user.Password = dataReader.GetString(2);
                                user.IsAdmin = dataReader.GetBoolean(3);
                                user.Email = dataReader.GetString(4);
                            }
                        }
                        conn.Close();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
                    throw new ArgumentException("Database error; cannot get Account");
                }
            }
            return user;
        }
        public UserDTO GetAccountByEmail(string email)
        {
            UserDTO user = new UserDTO();
            using (SqlConnection conn = new SqlConnection(DBAccess._connectionstring))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.spUser_GetUserByEmail", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Email", email);
                        conn.Open();
                        using (SqlDataReader dataReader = cmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                user.Id = dataReader.GetInt32(0);
                                user.UserName = dataReader.GetString(1);
                                user.Password = dataReader.GetString(2);
                                user.IsAdmin = dataReader.GetBoolean(3);
                                user.Email = dataReader.GetString(4);
                            }
                        }
                        conn.Close();
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex);
                    throw new ArgumentException("Database error: Cant get account by Email");
                }
                return user;
            }
        }
            public string GetAccountName(string username)
            {
                string usernamefromdb = null;
                using (SqlConnection conn = new SqlConnection(DBAccess._connectionstring))
                {
                    using (SqlCommand cmd = new SqlCommand("dbo.spUser_GetUsername", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username", username);
                        conn.Open();
                        using (SqlDataReader dataReader = cmd.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {

                                if (!dataReader.IsDBNull(1))
                                {
                                    usernamefromdb = dataReader.GetString(1);
                                }
                            }
                        }
                        conn.Close();
                        return usernamefromdb;
                    }
                }
            }
            public void Create(UserDTO obj)
            {
                using (SqlConnection conn = new SqlConnection(DBAccess._connectionstring))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.spAccount_Create", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Email", obj.Email);
                        cmd.Parameters.AddWithValue("@Password", obj.Password);
                        cmd.Parameters.AddWithValue("@Username", obj.UserName);
                        cmd.Parameters.AddWithValue("@IsAdmin", obj.IsAdmin);
                        cmd.ExecuteNonQuery();

                    }
                    conn.Close();
                }
            }

            public UserDTO Read(int key)
            {
                UserDTO user = new UserDTO();
                using (SqlConnection conn = new SqlConnection(DBAccess._connectionstring))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.spAccount_Read", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", key);
                        using (SqlDataReader datareader = cmd.ExecuteReader())
                        {
                            while (datareader.Read())
                            {
                                int Id = datareader.GetInt32(0);
                                string Email = datareader.GetString(1);
                                string Password = datareader.GetString(2);
                                string Username = datareader.GetString(3);
                                bool IsAdmin = datareader.GetBoolean(4);
                                if (!datareader.IsDBNull(0))
                                {
                                    user.Id = Id;
                                    user.Email = Email;
                                    user.Password = Password;
                                    user.UserName = Username;
                                    user.IsAdmin = IsAdmin;
                                }
                            }
                        }
                        conn.Close();
                    }
                }
                return user;
            }

            public void Update(UserDTO obj)
            {
                using (SqlConnection conn = new SqlConnection(DBAccess._connectionstring))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.spAccount_Update", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username", obj.UserName);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }

            public void Delete(UserDTO obj)
            {
                using (SqlConnection conn = new SqlConnection(DBAccess._connectionstring))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.spAccount_Delete", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@key", obj.Id);
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
        }
    }


