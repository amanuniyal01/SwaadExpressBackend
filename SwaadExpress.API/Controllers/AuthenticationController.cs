using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SwaadExpress.Domain.Modal.Dto;
using SwaadExpress.Domain.Modal.Entity;
using SwaadExpress.Domain.Validators;
using SwaadExpress.Interfaces.serviceInterface;

namespace SwaadExpress.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IValidator<RegisterUserDto> _registerValidator;
        private readonly IValidator<SendEmailOtpDto> _sendEmailOtpValidator;
        public readonly IValidator<LoginDto> _loginDtoValidator;
       
        private readonly IAuthenticationService _authenticateService;
       

            public AuthenticationController(IValidator<RegisterUserDto> registerValidator,
                IValidator<SendEmailOtpDto> sendEmailOtpValidator,
                IValidator<LoginDto> loginDtoValidator
                , IAuthenticationService authenticationService)
        {
            _registerValidator = registerValidator;
            _sendEmailOtpValidator = sendEmailOtpValidator;
            _authenticateService = authenticationService;
        }

        [HttpPost("RegisterUser")]
        public async Task<ActionResult<ResponseDto>> RegisterUser(RegisterUserDto user)
        {
            var validationResult = await _registerValidator.ValidateAsync(user);
            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var response = await _authenticateService.RegisterUserService(user);
            return Ok(response);
            
        }

        [HttpPost("SendEmailLoginOtp")]
        public async Task<ActionResult<ResponseDto>> SendEmailOtp(SendEmailOtpDto sendEmailOtpDto)
        {
            var validationResult = await _sendEmailOtpValidator.ValidateAsync(sendEmailOtpDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var response = await _authenticateService.SendLoginOtpToEmail(sendEmailOtpDto);
            return Ok(response);
        }


        [HttpPost("Login")]
        public async Task<ActionResult<TokenResponseDto>> Login(LoginDto loginDto)
        {
            var validationResult = await _loginDtoValidator.ValidateAsync(loginDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var response = await _authenticateService.LoginService(loginDto);
            return Ok(response);
        }
    }
}
