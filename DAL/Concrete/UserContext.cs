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
                using(SqlCommand cmd = new SqlCommand("AddAccount",conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Dispose();
                }

            }
        }
    }
}
