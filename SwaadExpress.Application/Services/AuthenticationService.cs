using AutoMapper;
using SwaadExpress.Application.Contracts.Repository;
using SwaadExpress.Domain.Modal.Dto;
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
            var userEntity=_mapper.Map<>
            var isUserAlreadyExist = await _authenticateRepo.IsUserAlreadyExistRepository(user);
            if (isUserAlreadyExist)
            {
                return new ResponseDto()
                {
                    Success = false,
                    Message = "Mobile Number or Email is already Registered."
                };
            }

            return new ResponseDto()
            {
                Success = true,
                Message="User Registered Successfully"
            };

        }
    }
}
