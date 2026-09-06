using AutoMapper;
using SwaadExpress.Application.Contracts.Repository;
using SwaadExpress.Domain.Modal.Dto;
using SwaadExpress.Domain.Modal.Entity;
using SwaadExpress.Interfaces.serviceInterface;

namespace SwaadExpress.Services
{
    public class AuthenticationService:IAuthenticationService
    {
        private readonly IAuthenticationRepository _authenticateRepo;
        private readonly IUserOtpRepository _userOtpRepo;
        private readonly IMapper _mapper;

        public AuthenticationService(IAuthenticationRepository authenticationRepository,
            IUserOtpRepository userOtpRepository,
             IMapper mapper)
        {
            _authenticateRepo = authenticationRepository;
            _userOtpRepo = userOtpRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto> RegisterUserService(RegisterUserDto user)

        {
            var userEntity = _mapper.Map<UserEntity>(user);
            var isUserAlreadyExist = await _authenticateRepo.IsUserAlreadyExistRepository(userEntity);
            if (isUserAlreadyExist)
            {
                return new ResponseDto()
                {
                    Success = false,
                    Message = " Email is already Registered."
                };
            }

            var result = await _authenticateRepo.RegisterUserRepository(userEntity);

            //if (result == null)
            //{
            //    return new ResponseDto()
            //    {
            //        Success = false,
            //        Message = "Unable to Register User"
            //    };
            //}

            return new ResponseDto()
            {
                Success = true,
                Message="User Registered Successfully"
            };

        }

        public async Task<ResponseDto> SendLoginOtpToEmail(SendEmailOtpDto sendLoginOtpDto)
        {

            //Get the otp details for given email.
            var response = await _userOtpRepo.GetUserOtpDetails(sendLoginOtpDto.Email);

            //Checks if otp for this email is already Present in Db or not;

            //If not present Create a New User with New Otp
            if (response == null)

            {

            }


            return new ResponseDto() {
            Success=true,
            Message="Otp Sent Successfully."
            
            };

        }
    }
}
