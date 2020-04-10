using System;
using System.Collections.Generic;
using System.Text;

namespace Crud.Models.DBModels
{
   public class Users
    {
        public Users()
        {
            Role = new Roles();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedDate { get; set; }
        public Roles Role { get; set; }
    }
}
