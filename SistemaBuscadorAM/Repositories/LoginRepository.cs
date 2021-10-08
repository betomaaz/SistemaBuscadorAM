using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBuscadorAM.Repositories
{
    public class LoginRepository
    {
        public async Task<bool> UserExist(string usuario, string password)
        {
            bool result = false;

            string connectionString = "server=LAPTOP-AI5P9O33;database=PRO402BD;Integrated Security=true;";
            using SqlConnection sql = new SqlConnection(connectionString);

            using SqlCommand cmd = new SqlCommand("sp_checkuser", sql);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@user", usuario));
            cmd.Parameters.Add(new SqlParameter("@password", password));
            await sql.OpenAsync();
            int bdResult = (int)cmd.ExecuteScalar();

            if (bdResult > 0)
            {
                result = true;
            }

            return result;
        }
    }
}
