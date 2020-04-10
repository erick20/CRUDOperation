using Crud.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Models.UserModels
{
    public class UserResponseModel
    {       
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Role { get; set; }
    }
}
