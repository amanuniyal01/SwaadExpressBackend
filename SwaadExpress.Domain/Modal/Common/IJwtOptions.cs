using System;
using System.Collections.Generic;
using System.Text;

namespace SwaadExpress.Domain.Modal.Common
{
    public interface IJwtOptions
    {
        string Secret { get; }
        public string Issuer { get; }
        public string Audience { get; }
        public int AccessTokenExpireTimeInSec { get; }
        public int RefreshTokenExpireTimeInSec { get; }
    }
}
