namespace WebAPI.Entities
{
    public class Student:BaseEntity
    {
        public string FullName { get; set; }
        public int DepartmentId{ get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public Department Department { get; set; }
    }
}