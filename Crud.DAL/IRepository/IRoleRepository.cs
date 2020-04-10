using Crud.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crud.DAL.IRepository
{
    public interface IRoleRepository
    {
        Task<Roles> getRole(int id);
    }
}
