using WebAPI.DTOs;

namespace WebAPI.Interface.Service
{
    public interface IDepartmentService
    {
        BaseResponse RegisterDepartment(CreateDepartmentRequest request);
        BaseResponse UpdateDepartment(UpdateDepartmentRequest request);
        DepartmentResponseModel GetDepartment(int id);
        DepartmentResponseModel GetDepartment(string name);
        DepartmentsResponseModel GetDepartments();
        BaseResponse DeleteDepartment(int id);
    }
}