using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using WebAPI.DTOs;
using WebAPI.Entities.Identity;
using WebAPI.Interface.Repository;

namespace WebAPI.Implementation.Repositories
{
    public class RoleRepository:IRoleRepository
    {
        private readonly ApplicationContext _context;

        public RoleRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Role> CreateRole(Role role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<bool> DeleteItem(Role role)
        {
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Role> EditItem(Role role)
        {
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<IList<Role>> GetAllRoles()
        {
            var roles = await _context.Roles.ToListAsync();
            return roles;
        }

        public async Task<Role> GetRole(int id)
        {
            var role = await _context.Roles.FindAsync(id);
            return role;
        }

        public async Task<IList<Role>> GetRolesByRoleIds(IList<int> roleIDs)
        {
            var roles = await _context.Roles.Where(x => roleIDs.Contains(x.Id)).ToListAsync();
            return roles;
        }

        public async Task<IList<UserRole>> GetRoleByUser(string email)
        {
            var role =await _context.UserRoles.Include(x => x.Role)
                .Where(x => x.User.Email == email).ToListAsync();
            return role;
        }
    }
}