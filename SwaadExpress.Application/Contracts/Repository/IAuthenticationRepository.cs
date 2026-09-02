using System;
using System.Collections.Generic;
using System.Text;
using SwaadExpress.Domain.Modal.Dto;
using SwaadExpress.Domain.Modal.Entity;

namespace SwaadExpress.Application.Contracts.Repository
{
    public interface IAuthenticationRepository
    {

         Task<bool> IsUserAlreadyExistRepository(UserEntity user);
        Task<UserEntity>  RegisterUserRepository(UserEntity user);

    }
}
