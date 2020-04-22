using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using System.Data.SqlClient;
using DAL.Access;
using System.Data.Common;
using System.Linq.Expressions;
using DTO;
using FilmGrain.Interfaces.Interfaces;

namespace DAL.Concrete
{
    public class UserContext : IUserContext
    {
        public void AddAccountToDB(UserDTO user)
        {
            using (SqlConnection conn = new SqlConnection(DBAccess._connectionstring))
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
        }

        public UserDTO GetAccountFromDB(string username, string password)
        {
            UserDTO user = new UserDTO();
            using (SqlConnection conn = new SqlConnection(DBAccess._connectionstring))
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
            return user;
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
    }
}

