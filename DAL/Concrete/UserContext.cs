using DAL.Interface;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using System.Data.SqlClient;
using DAL.Access;

namespace DAL.Concrete
{
    public class UserContext : IUserContext
    {
        public void AddAccountToDB(UserDTO user)
        {
            using (SqlConnection conn = new SqlConnection(DBAccess._connectionstring))
            {
                using(SqlCommand cmd = new SqlCommand("dbo.spUser_AddUser",conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", user.Id);
                    cmd.Parameters.AddWithValue("@Username", user.Name);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Dispose();
                }

            }
        }
    }
}
