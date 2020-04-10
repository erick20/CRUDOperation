using Crud.DAL.IRepository;
using Crud.Models.DBModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Crud.DAL.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private string connectionString;
        public RoleRepository(IConfiguration configuration)
        {
            connectionString = configuration["ConnectionStrings:CrudDB"].ToString();
        }
        public async Task<Roles> getRole(int id)
        {
            Roles _result = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetRole", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    await conn.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            _result = new Roles();
                            _result.Id = Convert.ToInt32(reader["Id"]);
                            _result.Role = reader["Role"].ToString();
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _result;
        }

        
    }
}
