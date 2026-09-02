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
        private readonly IMapper _mapper;
        public AuthenticationService(IAuthenticationRepository authenticationRepository , IMapper mapper)
        {
            _authenticateRepo = authenticationRepository;
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
    }
}
