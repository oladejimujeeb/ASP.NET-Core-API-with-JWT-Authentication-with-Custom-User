using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace WebAPI.Entities.Identity
{
    public class User:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string Salt{ get; set; }
        public ICollection<UserRole>UserRoles{ get; set; }= new HashSet<UserRole>();
    }
}