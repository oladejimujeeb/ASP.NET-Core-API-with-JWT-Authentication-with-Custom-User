using System.Collections.Generic;

namespace WebAPI.Entities
{
    public class Department:BaseEntity
    {
        public string DepartmentName { get; set; }
        public string College { get; set; }
        public IList<Student> Students { get; set; } = new List<Student>();
    }
}