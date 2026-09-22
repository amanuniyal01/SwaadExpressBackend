using SwaadExpress.Domain.Modal.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwaadExpress.Application.Contracts.Common
{
    public interface IJwtHandlerService
    {
        string GenerateToken(UserEntity user, string roleName);
    }
}
