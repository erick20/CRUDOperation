using Crud.DAL.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Crud.Models.DBModels;
using Crud.Models.UserModels;

namespace Crud.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private string connectionString;
        public UserRepository(IConfiguration configuration)
        {
            connectionString = configuration["ConnectionStrings:CrudDB"].ToString();
        }

        public async Task<Users> GetUser(int id)
        {
            Users _result = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    await conn.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            _result = new Users();
                            _result.Id = Convert.ToInt32(reader["Id"]);
                            _result.FirstName = reader["FirstName"].ToString();
                            _result.LastName = reader["LastName"].ToString();
                            _result.Email = reader["LastName"].ToString();
                            _result.Phone = reader["Phone"].ToString();
                            _result.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                            _result.Role.Id = Convert.ToInt32(reader["RoleId"]);
                            _result.Role.Role = reader["Role"].ToString();
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
        public async Task<List<Users>> GetUsers()
        {
            List<Users> _result = new List<Users>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetUsers", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    await conn.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        Users model;
                        while (await reader.ReadAsync())
                        {
                            model = new Users();
                            model.Id = Convert.ToInt32(reader["Id"]);
                            model.FirstName = reader["FirstName"].ToString();
                            model.LastName = reader["LastName"].ToString();
                            model.Email = reader["LastName"].ToString();
                            model.Phone = reader["Phone"].ToString();
                            model.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                            model.Role.Id = Convert.ToInt32(reader["RoleId"]);
                            model.Role.Role = reader["Role"].ToString();

                            _result.Add(model);
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

        public async Task<List<Users>> GetUsersByRole(int roleid)
        {
            List<Users> _result = new List<Users>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetUsersByRole", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@roleid", roleid);
                    await conn.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        Users model;
                        while (await reader.ReadAsync())
                        {
                            model = new Users();
                            model.Id = Convert.ToInt32(reader["Id"]);
                            model.FirstName = reader["FirstName"].ToString();
                            model.LastName = reader["LastName"].ToString();
                            model.Email = reader["LastName"].ToString();
                            model.Phone = reader["Phone"].ToString();
                            model.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                            model.Role.Id = Convert.ToInt32(reader["RoleId"]);
                            model.Role.Role = reader["Role"].ToString();

                            _result.Add(model);
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

        public async Task<List<Users>> GetUsersByDate(DateTime start, DateTime end)
        {
            List<Users> _result = new List<Users>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetUsersByDate", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@start", start);
                    cmd.Parameters.AddWithValue("@end", end);
                    await conn.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        Users model;
                        while (await reader.ReadAsync())
                        {
                            model = new Users();
                            model.Id = Convert.ToInt32(reader["Id"]);
                            model.FirstName = reader["FirstName"].ToString();
                            model.LastName = reader["LastName"].ToString();
                            model.Email = reader["LastName"].ToString();
                            model.Phone = reader["Phone"].ToString();
                            model.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                            model.Role.Id = Convert.ToInt32(reader["RoleId"]);
                            model.Role.Role = reader["Role"].ToString();

                            _result.Add(model);
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
        public async Task<Users> InsertUser(UserPostModel model)
        {
            Users _result = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("InsertUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;                    
                    cmd.Parameters.AddWithValue("@firstname", model.FirstName);
                    cmd.Parameters.AddWithValue("@lastname", model.LastName);
                    cmd.Parameters.AddWithValue("@email", model.Email);
                    cmd.Parameters.AddWithValue("@phone", model.Phone);
                    cmd.Parameters.AddWithValue("@roleid", model.RoleId);
                    await conn.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {                        
                        while (await reader.ReadAsync())
                        {
                            _result = new Users();
                            _result.Id = Convert.ToInt32(reader["Id"]);
                            _result.FirstName = reader["FirstName"].ToString();
                            _result.LastName = reader["LastName"].ToString();
                            _result.Email = reader["Email"].ToString();
                            _result.Phone = reader["Phone"].ToString();
                            _result.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                            _result.Role.Id = Convert.ToInt32(reader["RoleId"]);
                            _result.Role.Role = reader["Role"].ToString();
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

        public async Task<Users> UpdateUser(Users model)
        {
            Users _result = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("UpdateUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", model.Id);
                    cmd.Parameters.AddWithValue("@firstname", model.FirstName);
                    cmd.Parameters.AddWithValue("@lastname", model.LastName);
                    cmd.Parameters.AddWithValue("@email", model.Email);
                    cmd.Parameters.AddWithValue("@phone", model.Phone);
                    cmd.Parameters.AddWithValue("@roleid", model.Role.Id);
                    await conn.OpenAsync();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            _result = new Users();
                            _result.Id = Convert.ToInt32(reader["Id"]);
                            _result.FirstName = reader["FirstName"].ToString();
                            _result.LastName = reader["LastName"].ToString();
                            _result.Email = reader["Email"].ToString();
                            _result.Phone = reader["Phone"].ToString();
                            _result.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                            _result.Role.Id = Convert.ToInt32(reader["RoleId"]);                            
                            _result.Role.Role = reader["Role"].ToString();
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

        public async Task DeleteUser(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DeleteUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);
                    await conn.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
