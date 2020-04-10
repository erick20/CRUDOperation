using Crud.Models.DBModels;
using Crud.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crud.DAL.IRepository
{
    public interface IUserRepository
    {
        Task<Users> GetUser(int id);
        Task<List<Users>> GetUsers();
        Task<List<Users>> GetUsersByRole(int roleid);
        Task<List<Users>> GetUsersByDate(DateTime start, DateTime end);
        Task<Users> InsertUser(UserPostModel model);
        Task<Users> UpdateUser(Users model);
        Task DeleteUser(int id);
    }
}
