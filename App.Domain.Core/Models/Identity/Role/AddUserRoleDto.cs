using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Models.Identity.Role
{
    public class AddUserRoleDto
    {
        public AddUserRoleDto()
        {
            UserRole = new List<UserRoleDto>();
        }
        public string Id { get; set; }
        public List<UserRoleDto> UserRole { get; set; }

    }

    public class UserRoleDto
    {
        public string RoleName { get; set; }
        public bool IsSelected { get; set; }
    }
}
