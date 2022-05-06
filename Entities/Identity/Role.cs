using System.Collections;
using System.Collections.Generic;

namespace WebAPI.Entities.Identity
{
    public class Role:BaseEntity
    {
        /*public Role(string roleName)
        {
            RoleName = roleName;
        }*/
        public string RoleName { get; set; }
        public string Description { get; set; }
        public ICollection<UserRole>UserRoles{ get; set; }= new HashSet<UserRole>();
    }
}