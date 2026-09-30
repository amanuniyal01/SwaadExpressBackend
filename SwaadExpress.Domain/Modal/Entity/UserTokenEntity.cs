using System;
using System.Collections.Generic;
using System.Text;

namespace SwaadExpress.Domain.Modal.Entity
{
    public class UserTokenEntity
    {
        public int UserRefreshTokenId { get; set; }
        public string Token{ get; set; }
        public string RefreshToken { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpirationTime { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsInvalidated { get; set; } = false;

        public Guid UserId { get; set; }
    }
}
