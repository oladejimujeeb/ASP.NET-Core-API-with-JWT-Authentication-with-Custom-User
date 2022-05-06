using System.Collections.Generic;

namespace WebAPI.DTOs
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
    }

    public class RoleRequestModel
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
    }

    public class RoleResponseModel:BaseResponse
    {
        public RoleDto Data { get; set; }
    }

    public class RolesResponseModel : BaseResponse
    {
        public IList<RoleDto> Data { get; set; } = new List<RoleDto>();
    }
}