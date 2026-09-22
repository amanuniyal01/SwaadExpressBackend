
using Microsoft.Extensions.Configuration;
using System.Globalization;

namespace SwaadExpress.Domain.Modal.Common
{
    public class JwtOptions:IJwtOptions
    {
        private readonly IConfiguration _configuration;
        public JwtOptions(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Secret => _configuration["ApiSettings:JwtOptions:Secret"];
        public string Issuer => _configuration["ApiSettings:JwtOptions:Issuer"];
        public string Audience => _configuration["ApiSettings:JwtOptions:Audience"];

        public int AccessTokenExpireTimeInSec =>
            Convert.ToInt32(_configuration["ApiSettings:JwtOptions:AccessTokenExpireTimeInSec"]);

        public int RefreshTokenExpireTimeInSec =>
            Convert.ToInt32(_configuration["ApiSettings:JwtOptions:RefreshTokenExpireTimeInSec"]);



    }
}
