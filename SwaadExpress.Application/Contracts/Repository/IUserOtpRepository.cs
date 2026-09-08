using SwaadExpress.Domain.Modal.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwaadExpress.Application.Contracts.Repository
{
    public interface IUserOtpRepository
    {

        Task<UserEntity> GetUserOtpDetails(string email);
        
    }
}
