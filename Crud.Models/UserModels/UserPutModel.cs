using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Models.UserModels
{
    public class UserPutModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? RoleId { get; set; }
    }
}
