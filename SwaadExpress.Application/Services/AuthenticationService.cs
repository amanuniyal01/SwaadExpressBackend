using AutoMapper;
using SwaadExpress.Application.Contracts.Repository;
using SwaadExpress.Application.Contracts.Service;
using SwaadExpress.Domain.Constants;
using SwaadExpress.Domain.Modal.Dto;
using SwaadExpress.Domain.Modal.Entity;
using SwaadExpress.Domain.Modal.Enum;
using SwaadExpress.Interfaces.serviceInterface;
using static System.Net.WebRequestMethods;

namespace SwaadExpress.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _authenticateRepo;
        private readonly IUserOtpRepository _userOtpRepo;
        private readonly IRolesRepository _roleRepo;
        private readonly ISendEmailService _sendEmailService;
        private readonly IMapper _mapper;

        public AuthenticationService(IAuthenticationRepository authenticationRepository,
            IUserOtpRepository userOtpRepository,
            IRolesRepository roleRepo,
            ISendEmailService sendEmailService,
             IMapper mapper)
        {
            _authenticateRepo = authenticationRepository;
            _userOtpRepo = userOtpRepository;
            _sendEmailService = sendEmailService;
            _roleRepo = roleRepo;
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

            //var result = await _authenticateRepo.RegisterUserRepository(userEntity);

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
                Message = "User Registered Successfully"
            };

        }

        public async Task<ResponseDto> SendLoginOtpToEmail(SendEmailOtpDto sendLoginOtpDto)
        {
            var currentTime = DateTime.UtcNow;

            // Get the otp details for given email.
            var response = await _userOtpRepo.GetUserOtpDetails(sendLoginOtpDto.Email);
            string otp = RandomCodeGeneratorHelper.GenerateOTP(4);

            ResponseDto responseDto;

            // Case 1: No user exists yet for this email — create one with a fresh OTP.
            if (response == null)
            {
                var roles = await _roleRepo.GetRoles();
                UserEntity userEntity = new UserEntity()
                {
                    Email = sendLoginOtpDto.Email,
                    RoleId = roles.Where(r => r.RoleName == UserRoles.Admin.ToString()).Select(r => r.Id).FirstOrDefault(),
                    //UserName=
                    Otp = new UserOtpEntity()
                    {
                        Otp = otp,
                        Email = sendLoginOtpDto.Email,
                        ExpiryTime = currentTime.AddMinutes(OtpConstants.OtpExpiryMinutes),
                        TryCount = 1
                    }
                };

                responseDto = await _authenticateRepo.CreateUserRepository(userEntity);
            }
            else
            {
                // Case 2: User exists but has no OTP record yet.
                if (response.Otp == null)
                {
                    response.Otp = new UserOtpEntity()
                    {
                        Otp = otp,
                        ExpiryTime = currentTime.AddMinutes(OtpConstants.OtpExpiryMinutes),
                        TryCount = 1,
                        UserId = response.Id
                    };

                    responseDto = await _authenticateRepo.UpdateUser(response);
                }
                // Case 3: OTP record exists but has no email on it.
                else if (string.IsNullOrEmpty(response.Otp.Email))
                {
                    response.Otp = new UserOtpEntity()
                    {
                        Otp = otp,
                        ExpiryTime = currentTime.AddMinutes(OtpConstants.OtpExpiryMinutes),
                        TryCount = 1,
                        UserId = response.Id
                    };

                    responseDto = await _authenticateRepo.UpdateUser(response);
                }

                // Case 4: Try limit reached AND current OTP still valid — block the request.
                else if (response.Otp.TryCount >= OtpConstants.OtpTryCount && response.Otp.ExpiryTime > currentTime)
                {
                    return new ResponseDto()
                    {
                        Success = false,
                        Message = "Maximum otp Limit Reached!"
                    };
                }

                // Case 5: Current OTP still valid, under the try limit — increment attempts.
                else if (response.Otp.ExpiryTime > currentTime)
                {
                    response.Otp.TryCount++;
                    response.Otp.Otp = otp;
                    response.Otp.ExpiryTime = currentTime.AddMinutes(OtpConstants.OtpExpiryMinutes);

                    responseDto = await _authenticateRepo.UpdateUser(response);
                }

                // Case 6: Old OTP expired — reset try count for a fresh window.
                else
                {
                    response.Otp.TryCount = 1;
                    response.Otp.Otp = otp;
                    response.Otp.ExpiryTime = currentTime.AddMinutes(OtpConstants.OtpExpiryMinutes);

                    responseDto = await _authenticateRepo.UpdateUser(response);
                }
            }

            if (!responseDto.Success)
            {
                return responseDto;
            }

            try
            {
                await _sendEmailService.SendOtp(sendLoginOtpDto.Email, otp); 
            }
            catch
            {
                return new ResponseDto()
                {
                    Success = false,
                    Message = "Something went wrong while sending the OTP."
                };
            }

            return new ResponseDto()
            {
                Success = true,
                Message = "Otp Sent Successfully."
            };
        }
    }
}