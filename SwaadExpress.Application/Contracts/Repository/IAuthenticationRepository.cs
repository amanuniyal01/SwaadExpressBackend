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
        Task<ResponseDto> CreateUserRepository(UserEntity user);
        Task<ResponseDto> UpdateUser(UserEntity userEntity);

    }
}
