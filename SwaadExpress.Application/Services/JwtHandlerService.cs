using Microsoft.IdentityModel.Tokens;
using SwaadExpress.Application.Contracts.Common;
using SwaadExpress.Domain.Modal.Common;
using SwaadExpress.Domain.Modal.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SwaadExpress.Application.Services
{
    public class JwtHandlerService : IJwtHandlerService
    {
        private readonly IJwtOptions _jwtoptions;

        public JwtHandlerService(IJwtOptions jwtOptions)
        {
            _jwtoptions = jwtOptions;
        }
       public  string GenerateToken(UserEntity user , string roleName)
        {
            var CurrentTime = DateTime.UtcNow;
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtoptions.Secret);


            //Info put inside JWT about user.
            var claims = new List<Claim>
            {
                new Claim (ClaimTypes.Role , roleName),
                new Claim (JwtRegisteredClaimNames.Sub,user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email , user.Email)

            };

            //Create TOken on the basis of this info saved in appSettings.
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _jwtoptions.Audience,
                
                Issuer = _jwtoptions.Issuer,

                Subject = new ClaimsIdentity(claims),

                Expires = CurrentTime.AddMinutes(_jwtoptions.AccessTokenExpireTimeInSec),

                SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };

            //Create Token
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);

        }
    }
}
