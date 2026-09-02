using SwaadExpress.Domain.Modal.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwaadExpress.Interfaces.serviceInterface
{
    public interface IAuthenticationService
    {
        Task<ResponseDto> RegisterUserService(RegisterUserDto user);
    }
}
