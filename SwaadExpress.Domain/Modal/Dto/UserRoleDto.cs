using System;
using System.Collections.Generic;
using System.Text;

namespace SwaadExpress.Domain.Modal.Dto
{
    public class UserRoleDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string roleName { get; set; }

    }
}
