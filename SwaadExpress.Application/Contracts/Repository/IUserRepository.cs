using SwaadExpress.Domain.Modal.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwaadExpress.Application.Contracts.Repository
{
    public interface IUserRepository
    {

        Task<UserRoleDto> GetUserWithRole(Guid userId);
    }
}
