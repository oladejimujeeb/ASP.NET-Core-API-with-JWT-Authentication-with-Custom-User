using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;
using WebAPI.Entities.Identity;

namespace WebAPI.Context
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Student>Students { get; set; }
        public DbSet<Department>Departments { get; set; }
        public DbSet<Role>Roles { get; set; }
        public DbSet<User>Users { get; set; }
        public DbSet<UserRole>UserRoles { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User()
            {
                FirstName = UserConstant.FirstName,
                LastName = UserConstant.LastName,
                PhoneNumber = UserConstant.default_PhoneNumber,
                Email = UserConstant.default_email,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                Password = UserConstant.default_password,
                Id = 1,
                
            });
            modelBuilder.Entity<Role>().HasData(new Role()
            {
                RoleName = "Administrator",
                Description = "General Admin",
                Id = 1,
            });
            modelBuilder.Entity<UserRole>().HasData(new UserRole()
            {
                Id = 1,
                RoleId = 1,
                UserId = 1,
            });
        }
    }
}