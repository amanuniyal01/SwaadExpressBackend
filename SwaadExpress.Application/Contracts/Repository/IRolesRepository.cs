using SwaadExpress.Domain.Modal.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwaadExpress.Application.Contracts.Repository
{
    public interface IRolesRepository
    {
        Task<List<RoleEntity>> GetRoles();
    }
}
