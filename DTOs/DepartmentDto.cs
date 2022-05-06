using System.Collections.Generic;

namespace WebAPI.DTOs
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string College { get; set; }
    }
    public class CreateDepartmentRequest
    {
        public string DepartmentName { get; set; }
        public string College { get; set; }
    }

    public class UpdateDepartmentRequest
    {
        public string DepartmentName { get; set; }
        public string College { get; set; }
    }

    public class DepartmentResponseModel : BaseResponse
    {
        public DepartmentDto Data { get; set;}
    }

    public class DepartmentsResponseModel : BaseResponse
    {
        public IList<DepartmentDto> Data { get; set; }
    }
}