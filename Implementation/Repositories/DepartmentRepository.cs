using WebAPI.Context;
using WebAPI.Entities;
using WebAPI.Interface.Repository;

namespace WebAPI.Implementation.Repositories
{
    public class DepartmentRepository:BaseRepository<Department>,IDepartmentRepository
    {
        public DepartmentRepository(ApplicationContext context)
        {
            _context = context;
        }
    }
}