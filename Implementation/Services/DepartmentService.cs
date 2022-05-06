using System.Linq;
using WebAPI.DTOs;
using WebAPI.Entities;
using WebAPI.Interface.Repository;
using WebAPI.Interface.Service;

namespace WebAPI.Implementation.Services
{
    public class DepartmentService:IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public BaseResponse DeleteDepartment(int id)
        {
            var department = _departmentRepository.Get(x => x.Id == id);
            if(department != null)
            {
                _departmentRepository.Delete(department);
                return new BaseResponse
                {
                    Status = true,
                    Message = $"Department with {department.DepartmentName} successfully deleted"
                };
            }
            return new BaseResponse
            {
                Status = false,
                Message = $"Department with {id} not found"
            };
        }

        public DepartmentResponseModel GetDepartment(int id)
        {
            var department = _departmentRepository.Get(x => x.Id == id);
            if( department != null)
            {
                return new DepartmentResponseModel
                {
                    Data = new DepartmentDto
                    {
                        Id = department.Id,
                        DepartmentName = department.DepartmentName,
                        College = department.College,
                    },
                    Status = true,
                    Message = $"Department with name {department.DepartmentName} succesfully retrieved"
                };
            }
            return new DepartmentResponseModel
            {
                Message = "not found",
                Status = false
            };
            
        }

        public DepartmentResponseModel GetDepartment(string name)
        {
            var department = _departmentRepository.Get(x => x.DepartmentName == name);
            if (department != null)
            {
                return new DepartmentResponseModel
                {
                    Data = new DepartmentDto
                    {
                        Id = department.Id,
                        DepartmentName = department.DepartmentName,
                        College = department.College,
                    },
                    Status = true,
                    Message = $"Department with name {department.DepartmentName} succesfully retrieved"
                };
            }
            return new DepartmentResponseModel
            {
                Message = "not found",
                Status = false
            };
        }

        public DepartmentsResponseModel GetDepartments()
        {
            var departments = _departmentRepository.GetAll();
            return new DepartmentsResponseModel
            {
                Data = departments.Select(department => new DepartmentDto
                {
                    Id = department.Id,
                    DepartmentName = department.DepartmentName,
                    College = department.College,
                }).ToList(),
                Message = "Successfully retrieved",
                Status = true
            };
        }

        public BaseResponse RegisterDepartment(CreateDepartmentRequest request)
        {
            var departmentExist = _departmentRepository.Exists(x => x.DepartmentName == request.DepartmentName);
            if (departmentExist)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = "Already exist"
                };
            }
            var department = new Department
            {
                DepartmentName = request.DepartmentName,
                College = request.DepartmentName,
            };
            _departmentRepository.Add(department);
            return new BaseResponse
            {
                Message = "succesfully created",
                Status = true,
            };
            
        }

        public BaseResponse UpdateDepartment(UpdateDepartmentRequest request)
        {
            var department = _departmentRepository.Get(x => x.DepartmentName == request.DepartmentName);
            if (department == null)
            {
                return new BaseResponse
                {
                    Status = false,
                    Message = "Department does not exist"
                };
            }
            if (request.DepartmentName != null && !department.DepartmentName.Equals(request.DepartmentName)) 
            {

                department.DepartmentName = request.DepartmentName;
            }
            if (request.College != null && !department.College.Equals(request.College)) department.College = request.College;
            _departmentRepository.Update(department);
            return new BaseResponse
            {
                Message = "succesfully edited",
                Status = true,
            };
        }
    }
}