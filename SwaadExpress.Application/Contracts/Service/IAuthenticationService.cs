using SwaadExpress.Domain.Modal.Dto;
using SwaadExpress.Domain.Modal.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwaadExpress.Interfaces.serviceInterface
{
    public interface IAuthenticationService
    {
        Task<ResponseDto> RegisterUserService(RegisterUserDto user);
        Task<ResponseDto> SendLoginOtpToEmail(SendEmailOtpDto sendLoginOtpDto);
        Task<TokenUserDetailsDto> LoginService(LoginDto loginDto);
    }
}
