using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs;
using WebAPI.Interface.Service;

namespace WebAPI.Controllers
{
    //[Route("test/dep")]
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        
        [HttpPost("department/Register")]
        public IActionResult RegisterDepartment(CreateDepartmentRequest request)
        {
            _departmentService.RegisterDepartment(request);
            return Ok(request);
        }

        [HttpGet]
        public IActionResult GetDepartment(int id)
        {
            if(id == 0)
            {
                return BadRequest("Wrong data input");
            }
            var department = _departmentService.GetDepartment(id);
            if(!department.Status)
            {
                return NotFound(department.Message);
            }
            else
            {
                return Ok(department);
            }
   
        }
    }
}